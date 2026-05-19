using AbrPlus.Cloud.Stream.IService;
using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;
using AbrPlus.Integration.OpenCRM.SampleCRM.Mappers;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    public interface ILookupSourceActionsService
    {
        Task<MoneyAccountsResponse> GetMoneyAccounts();
        Task<BillableObjectTypesResponse> GetBillableObjectTypes();
        Task<BillableObjectTypePropsResponse> GetBillableObjectTypeProps(BillableObjectTypePropsRequest billableObjectTypePropsRequest);
        Task<PaymentResponse> GetPaymentInfo(PaymentInfoRequest paymentInfoRequest);
        Task<SendPaymentLinkToUserResponse> SendPaymentLinkToUser(SendPaymentLinkToUserRequest sendPaymentLinkToUserRequest);
        Task<CrmObjectUrlResponse> GetCrmObjectUrl(CrmObjectUrlRequest crmObjectUrlRequest);
        Task<CardtableResponse> GetCardtable(CardtableRequest cardtableRequest);
        Task<UserExtensionResponse> GetUserDefaultExtension(UserExtensionRequest userExtensionRequest);
        Task<UserResponse> GetUserInfoByIdentityId(UserInfoByIdentityRequest userInfoByIdentityRequest);
        Task<UserTelephonySystemResponse> GetUserExtensions(UserExtensionsRequest userExtenstionsRequest);
        Task<UserExtensionResponse> GetUserManagerExtension(UserManagerByExtensionRequest userManagerByExtensionRequest);
        Task<IdentityResponse> GetIdentityByCustomerInfo(CustomerRequest customerRequest);
        Task<IdentityResponse> GetIdentityByPhoneNumber(IdentityByPhoneNumberRequest identityByPhoneNumberRequest);
        Task<IdentityResponse> GetIdentityByCustomerNumber(IdentityByCustomerNumberRequest identityByCustomerNumberRequest);
        Task<IdentityBalanceResponse> GetIdentityBalance(CustomerRequest customerRequest);
        Task<CreateInvoiceResponse> CreateInvoice(CreateSalesInvoiceRequest createSalesInvoiceRequest);
        Task<IdentityContractStatusResponse> GetIdentityContractStatus(IdentityContractStatusRequest identityHasValidContractRequest);
        Task<SubmitQueueOperatorVotingResponse> SubmitQueueOperatorVoting(SubmitQueueOperatorVotingRequest submitQueueOperatorVotingRequest);
        Task<SubmitVotingResponse> SubmitVoting(SubmitVotingRequest submitVotingRequest);
    }

    public class LookupSourceActionsService : ILookupSourceActionsService
    {
        private readonly ILogger<LookupSourceActionsService> _logger;
        private readonly IOpenCRMHubService _openCRMHubService;

        public LookupSourceActionsService(ILogger<LookupSourceActionsService> logger, IOpenCRMHubService openCRMHubService)
        {
            _logger = logger;
            _openCRMHubService = openCRMHubService;
        }

        public Task<MoneyAccountsResponse> GetMoneyAccounts()
        {
            _logger.LogInformation("REST /financial/moneyAccounts called.");
            return Task.FromResult(CallStoreMapper.ToMoneyAccountsResponse());
        }

        public Task<BillableObjectTypesResponse> GetBillableObjectTypes()
        {
            _logger.LogInformation("REST /financial/billableObjectTypes called.");
            return Task.FromResult(CallStoreMapper.ToBillableObjectTypesResponse());
        }

        public Task<BillableObjectTypePropsResponse> GetBillableObjectTypeProps(BillableObjectTypePropsRequest billableObjectTypePropsRequest)
        {
            _logger.LogInformation("REST /financial/billableObjectTypeProps called. Request: {request}", LogJsonSerializer.Serialize(billableObjectTypePropsRequest));
            return Task.FromResult(billableObjectTypePropsRequest.ToResponse());
        }

        public Task<PaymentResponse> GetPaymentInfo(PaymentInfoRequest paymentInfoRequest)
        {
            _logger.LogInformation("REST /financial/paymentInfo called. Request: {request}", LogJsonSerializer.Serialize(paymentInfoRequest));
            return Task.FromResult(paymentInfoRequest.ToResponse());
        }

        public Task<SendPaymentLinkToUserResponse> SendPaymentLinkToUser(SendPaymentLinkToUserRequest sendPaymentLinkToUserRequest)
        {
            _logger.LogInformation("REST /financial/sendPaymentLinkToUser called. Request: {request}", LogJsonSerializer.Serialize(sendPaymentLinkToUserRequest));
            return Task.FromResult(sendPaymentLinkToUserRequest.ToResponse());
        }

        public Task<CrmObjectUrlResponse> GetCrmObjectUrl(CrmObjectUrlRequest crmObjectUrlRequest)
        {
            _logger.LogInformation("REST /general/findCrmObjectUrl called. Request: {request}", LogJsonSerializer.Serialize(crmObjectUrlRequest));
            return Task.FromResult(crmObjectUrlRequest.ToResponse());
        }

        public Task<CardtableResponse> GetCardtable(CardtableRequest cardtableRequest)
        {
            _logger.LogInformation("REST /user/cardtable called. Request: {request}", LogJsonSerializer.Serialize(cardtableRequest));
            return Task.FromResult(cardtableRequest.ToResponse());
        }

        public Task<UserExtensionResponse> GetUserDefaultExtension(UserExtensionRequest userExtensionRequest)
        {
            _logger.LogInformation("REST /user/defaultExtension called. Request: {request}", LogJsonSerializer.Serialize(userExtensionRequest));
            return Task.FromResult(userExtensionRequest.ToResponse());
        }

        public Task<UserResponse> GetUserInfoByIdentityId(UserInfoByIdentityRequest userInfoByIdentityRequest)
        {
            _logger.LogInformation("REST /user/userInfoByIdentityId called. Request: {request}", LogJsonSerializer.Serialize(userInfoByIdentityRequest));
            return Task.FromResult(userInfoByIdentityRequest.ToResponse());
        }

        public Task<UserTelephonySystemResponse> GetUserExtensions(UserExtensionsRequest userExtenstionsRequest)
        {
            _logger.LogInformation("REST /user/userExtensions called. Request: {request}", LogJsonSerializer.Serialize(userExtenstionsRequest));
            return Task.FromResult(userExtenstionsRequest.ToResponse());
        }

        public Task<UserExtensionResponse> GetUserManagerExtension(UserManagerByExtensionRequest userManagerByExtensionRequest)
        {
            _logger.LogInformation("REST /user/userManagerExtension called. Request: {request}", LogJsonSerializer.Serialize(userManagerByExtensionRequest));
            return Task.FromResult(userManagerByExtensionRequest.ToResponse());
        }

        public Task<IdentityResponse> GetIdentityByCustomerInfo(CustomerRequest customerRequest)
        {
            _logger.LogInformation("REST /identity/findByCustomerInfo called. Request: {request}", LogJsonSerializer.Serialize(customerRequest));
            return Task.FromResult(customerRequest.ToResponse());
        }

        public Task<IdentityResponse> GetIdentityByPhoneNumber(IdentityByPhoneNumberRequest identityByPhoneNumberRequest)
        {
            _logger.LogInformation("REST /identity/findByPhoneNumber called. Request: {request}", LogJsonSerializer.Serialize(identityByPhoneNumberRequest));
            return Task.FromResult(identityByPhoneNumberRequest.ToResponse());
        }

        public Task<IdentityResponse> GetIdentityByCustomerNumber(IdentityByCustomerNumberRequest identityByCustomerNumberRequest)
        {
            _logger.LogInformation("REST /identity/findByCustomerNumber called. Request: {request}", LogJsonSerializer.Serialize(identityByCustomerNumberRequest));
            return Task.FromResult(identityByCustomerNumberRequest.ToResponse());
        }

        public Task<IdentityBalanceResponse> GetIdentityBalance(CustomerRequest customerRequest)
        {
            _logger.LogInformation("REST /identity/balance called. Request: {request}", LogJsonSerializer.Serialize(customerRequest));
            return Task.FromResult(customerRequest.ToBalanceResponse());
        }

        public Task<CreateInvoiceResponse> CreateInvoice(CreateSalesInvoiceRequest createSalesInvoiceRequest)
        {
            _logger.LogInformation("REST /invoice/salesInvoice called. Request: {request}", LogJsonSerializer.Serialize(createSalesInvoiceRequest));
            return Task.FromResult(createSalesInvoiceRequest.ToResponse());
        }

        public Task<IdentityContractStatusResponse> GetIdentityContractStatus(IdentityContractStatusRequest identityHasValidContractRequest)
        {
            _logger.LogInformation("REST /contract/identityContractStatus called. Request: {request}", LogJsonSerializer.Serialize(identityHasValidContractRequest));
            return Task.FromResult(identityHasValidContractRequest.ToResponse());
        }

        public async Task<SubmitQueueOperatorVotingResponse> SubmitQueueOperatorVoting(SubmitQueueOperatorVotingRequest submitQueueOperatorVotingRequest)
        {
            _logger.LogInformation("REST /voting/queueOperatorVoting called. Request: {request}", LogJsonSerializer.Serialize(submitQueueOperatorVotingRequest));
            await _openCRMHubService.SubmitQueueOperatorVoting(submitQueueOperatorVotingRequest);
            return submitQueueOperatorVotingRequest.ToResponse();
        }

        public async Task<SubmitVotingResponse> SubmitVoting(SubmitVotingRequest submitVotingRequest)
        {
            _logger.LogInformation("REST /voting/voting called. Request: {request}", LogJsonSerializer.Serialize(submitVotingRequest));
            await _openCRMHubService.SubmitVoting(submitVotingRequest);
            return submitVotingRequest.ToResponse();
        }
    }
}
