using AbrPlus.Integration.OpenCRM.Requests;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    public interface IJsonRpcActionsService
    {
        Task<JsonRpcResponse<object>> Invoke(JsonRpcRequest<JsonElement> request);
    }

    public class JsonRpcActionsService : IJsonRpcActionsService
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        private readonly ILogger<JsonRpcActionsService> _logger;
        private readonly ICallStoreActionsService _callStoreActionsService;
        private readonly ILookupSourceActionsService _lookupSourceActionsService;

        public JsonRpcActionsService(
            ILogger<JsonRpcActionsService> logger,
            ICallStoreActionsService callStoreActionsService,
            ILookupSourceActionsService lookupSourceActionsService)
        {
            _logger = logger;
            _callStoreActionsService = callStoreActionsService;
            _lookupSourceActionsService = lookupSourceActionsService;
        }

        public async Task<JsonRpcResponse<object>> Invoke(JsonRpcRequest<JsonElement> request)
        {
            _logger.LogInformation("JSON-RPC called. Method: {method}, Id: {id}, Params: {params}", request?.Method, request?.Id, request?.Params.ToString());

            if (request == null)
            {
                return Error(null, -32600, "Invalid Request");
            }

            try
            {
                var result = await Dispatch(request.Method, request.Params);

                return new JsonRpcResponse<object>
                {
                    Id = request.Id,
                    Result = result
                };
            }
            catch (NotSupportedException ex)
            {
                _logger.LogWarning(ex, "JSON-RPC method not found. Method: {method}", request.Method);
                return Error(request.Id, -32601, ex.Message);
            }
            catch (JsonException ex)
            {
                _logger.LogWarning(ex, "JSON-RPC invalid params. Method: {method}, Params: {params}", request.Method, request.Params.ToString());
                return Error(request.Id, -32602, "Invalid params");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "JSON-RPC internal error. Method: {method}", request.Method);
                return Error(request.Id, -32000, "Internal server error");
            }
        }

        private async Task<object> Dispatch(string method, JsonElement parameters)
        {
            switch (method)
            {
                case "call_created":
                    return await _callStoreActionsService.CallCreated(ToObject<CallCreateRequest>(parameters));

                case "call_updated":
                    return await _callStoreActionsService.CallUpdated(ToObject<CallUpdateRequest>(parameters));

                case "call_channelCreated":
                    return await _callStoreActionsService.CallChannelCreated(ToObject<CallChannelCreateRequest>(parameters));

                case "call_channelUpdated":
                    return await _callStoreActionsService.CallChannelUpdated(ToObject<CallChannelUpdateRequest>(parameters));

                case "call_merge":
                    return await _callStoreActionsService.MergeCall(ToObject<MergeCallRequest>(parameters));

                case "financial_moneyAccounts":
                    return await _lookupSourceActionsService.GetMoneyAccounts();

                case "financial_billableObjectTypes":
                    return await _lookupSourceActionsService.GetBillableObjectTypes();

                case "financial_billableObjectTypeProps":
                    return await _lookupSourceActionsService.GetBillableObjectTypeProps(ToObject<BillableObjectTypePropsRequest>(parameters));

                case "financial_paymentInfo":
                    return await _lookupSourceActionsService.GetPaymentInfo(ToObject<PaymentInfoRequest>(parameters));

                case "financial_sendPaymentLinkToUser":
                    return await _lookupSourceActionsService.SendPaymentLinkToUser(ToObject<SendPaymentLinkToUserRequest>(parameters));

                case "general_findCrmObjectUrl":
                    return await _lookupSourceActionsService.GetCrmObjectUrl(ToObject<CrmObjectUrlRequest>(parameters));

                case "user_cardtable":
                    return await _lookupSourceActionsService.GetCardtable(ToObject<CardtableRequest>(parameters));

                case "user_defaultExtension":
                    return await _lookupSourceActionsService.GetUserDefaultExtension(ToObject<UserExtensionRequest>(parameters));

                case "user_userInfoByIdentityId":
                    return await _lookupSourceActionsService.GetUserInfoByIdentityId(ToObject<UserInfoByIdentityRequest>(parameters));

                case "user_userExtensions":
                    return await _lookupSourceActionsService.GetUserExtensions(ToObject<UserExtensionsRequest>(parameters));

                case "user_userManagerExtension":
                    return await _lookupSourceActionsService.GetUserManagerExtension(ToObject<UserManagerByExtensionRequest>(parameters));

                case "identity_findByCustomerInfo":
                    return await _lookupSourceActionsService.GetIdentityByCustomerInfo(ToObject<CustomerRequest>(parameters));

                case "identity_findByPhoneNumber":
                    return await _lookupSourceActionsService.GetIdentityByPhoneNumber(ToObject<IdentityByPhoneNumberRequest>(parameters));

                case "identity_findByCustomerNumber":
                    return await _lookupSourceActionsService.GetIdentityByCustomerNumber(ToObject<IdentityByCustomerNumberRequest>(parameters));

                case "identity_balance":
                    return await _lookupSourceActionsService.GetIdentityBalance(ToObject<CustomerRequest>(parameters));

                case "invoice_salesInvoice":
                    return await _lookupSourceActionsService.CreateInvoice(ToObject<CreateSalesInvoiceRequest>(parameters));

                case "contract_identityContractStatus":
                    return await _lookupSourceActionsService.GetIdentityContractStatus(ToObject<IdentityContractStatusRequest>(parameters));

                case "voting_queueOperatorVoting":
                    return await _lookupSourceActionsService.SubmitQueueOperatorVoting(ToObject<SubmitQueueOperatorVotingRequest>(parameters));

                case "voting_voting":
                    return await _lookupSourceActionsService.SubmitVoting(ToObject<SubmitVotingRequest>(parameters));

                default:
                    throw new NotSupportedException("Method not found: " + method);
            }
        }

        private static T ToObject<T>(JsonElement parameters)
        {
            if (parameters.ValueKind == JsonValueKind.Undefined || parameters.ValueKind == JsonValueKind.Null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(parameters.GetRawText(), JsonOptions);
        }

        private static JsonRpcResponse<object> Error(string id, int code, string message)
        {
            return new JsonRpcResponse<object>
            {
                Id = id,
                Error = new JsonRpcError
                {
                    Code = code,
                    Message = message
                }
            };
        }
    }

    public class JsonRpcRequest<TParams>
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("params")]
        public TParams Params { get; set; }
    }

    public class JsonRpcResponse<TResult>
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("result")]
        public TResult Result { get; set; }

        [JsonPropertyName("error")]
        public JsonRpcError Error { get; set; }
    }

    public class JsonRpcError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
