using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    [ApiController]
    public class LookupSourceController : ControllerBase
    {

        private readonly ILogger<LookupSourceController> _logger;

        public LookupSourceController(ILogger<LookupSourceController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/financial/moneyAccounts")]
        public Task<MoneyAccountsResponse> GetMoneyAccounts()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/financial/billableObjectTypes")]
        public Task<BillableObjectTypesResponse> GetBillableObjectTypes()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/financial/billableObjectTypeProps")]
        public Task<BillableObjectTypePropsResponse> GetBillableObjectTypeProps([FromQuery] BillableObjectTypePropsRequest billableObjectTypePropsRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/financial/paymentInfo")]
        public Task<PaymentResponse> GetPaymentInfo([FromQuery] PaymentInfoRequest paymentInfoRequest)
        {
            throw new NotImplementedException();
        }
        [HttpPost("/financial/sendPaymentLinkToUser")]
        public Task<SendPaymentLinkToUserResponse> SendPaymentLinkToUser([FromBody] SendPaymentLinkToUserRequest sendPaymentLinkToUserRequest)
        {
            throw new NotImplementedException();
        }


        [HttpGet("/general/findCrmObjectUrl")]
        public Task<CrmObjectUrlResponse> GetCrmObjectUrl([FromQuery] CrmObjectUrlRequest crmObjectUrlRequest)
        {
            throw new NotImplementedException();
        }


        [HttpGet("/user/cardtable")]
        public Task<CardtableResponse> GetCardtable([FromQuery] CardtableRequest cardtableRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/user/defaultExtension")]
        public Task<UserExtensionResponse> GetUserDefaultExtension([FromQuery] UserExtensionRequest userExtensionRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/user/userInfoByIdentityId")]
        public Task<UserResponse> GetUserInfoByIdentityId([FromQuery] UserInfoByIdentityRequest userInfoByIdentityRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/user/userExtensions")]
        public Task<UserTelephonySystemResponse> GetUserExtensions([FromQuery] UserExtensionsRequest userExtenstionsRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/user/userManagerExtension")]
        public Task<UserExtensionResponse> GetUserManagerExtension([FromQuery] UserManagerByExtensionRequest userManagerByExtensionRequest)
        {
            throw new NotImplementedException();
        }


        [HttpGet("/identity/findByCustomerInfo")]
        public Task<IdentityResponse> GetIdentityByCustomerInfo([FromQuery] CustomerRequest customerRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/identity/findByPhoneNumber")]
        public Task<IdentityResponse> GetIdentityByPhoneNumber([FromQuery] IdentityByPhoneNumberRequest identityByPhoneNumberRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/identity/findByCustomerNumber")]
        public Task<IdentityResponse> GetIdentityByCustomerNumber([FromQuery] IdentityByCustomerNumberRequest identityByCustomerNumberRequest)
        {
            throw new NotImplementedException();
        }
        [HttpGet("/identity/balance")]
        public Task<IdentityBalanceResponse> GetIdentityBalance([FromQuery] CustomerRequest customerRequest)
        {
            throw new NotImplementedException();
        }


        [HttpPost("/invoice/salesInvoice")]
        public Task<CreateInvoiceResponse> CreateInvoice([FromBody] CreateSalesInvoiceRequest createSalesInvoiceRequest)
        {
            throw new NotImplementedException();
        }



        [HttpGet("/contract/identityContractStatus")]
        public Task<IdentityContractStatusResponse> GetIdentityContractStatus([FromQuery] IdentityContractStatusRequest identityHasValidContractRequest)
        {
            throw new NotImplementedException();
        }



        [HttpPost("/voting/queueOperatorVoting")]
        public Task<SubmitQueueOperatorVotingResponse> SubmitQueueOperatorVoting([FromBody] SubmitQueueOperatorVotingRequest submitQueueOperatorVotingRequest)
        {
            throw new NotImplementedException();
        }
        [HttpPost("/voting/voting")]
        public Task<SubmitVotingResponse> SubmitVoting([FromBody] SubmitVotingRequest submitVotingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
