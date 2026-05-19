using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    [ApiController]
    [Route("private")]
    [Authorize]
    public class PrivateLookupSourceController : ControllerBase
    {
        private readonly ILookupSourceActionsService _actions;

        public PrivateLookupSourceController(ILookupSourceActionsService actions)
        {
            _actions = actions;
        }

        [HttpGet("financial/moneyAccounts")]
        public Task<MoneyAccountsResponse> GetMoneyAccounts()
        {
            return _actions.GetMoneyAccounts();
        }

        [HttpGet("financial/billableObjectTypes")]
        public Task<BillableObjectTypesResponse> GetBillableObjectTypes()
        {
            return _actions.GetBillableObjectTypes();
        }

        [HttpGet("financial/billableObjectTypeProps")]
        public Task<BillableObjectTypePropsResponse> GetBillableObjectTypeProps([FromQuery] BillableObjectTypePropsRequest billableObjectTypePropsRequest)
        {
            return _actions.GetBillableObjectTypeProps(billableObjectTypePropsRequest);
        }

        [HttpGet("financial/paymentInfo")]
        public Task<PaymentResponse> GetPaymentInfo([FromQuery] PaymentInfoRequest paymentInfoRequest)
        {
            return _actions.GetPaymentInfo(paymentInfoRequest);
        }

        [HttpPost("financial/sendPaymentLinkToUser")]
        public Task<SendPaymentLinkToUserResponse> SendPaymentLinkToUser([FromBody] SendPaymentLinkToUserRequest sendPaymentLinkToUserRequest)
        {
            return _actions.SendPaymentLinkToUser(sendPaymentLinkToUserRequest);
        }

        [HttpGet("general/findCrmObjectUrl")]
        public Task<CrmObjectUrlResponse> GetCrmObjectUrl([FromQuery] CrmObjectUrlRequest crmObjectUrlRequest)
        {
            return _actions.GetCrmObjectUrl(crmObjectUrlRequest);
        }

        [HttpGet("user/cardtable")]
        public Task<CardtableResponse> GetCardtable([FromQuery] CardtableRequest cardtableRequest)
        {
            return _actions.GetCardtable(cardtableRequest);
        }

        [HttpGet("user/defaultExtension")]
        public Task<UserExtensionResponse> GetUserDefaultExtension([FromQuery] UserExtensionRequest userExtensionRequest)
        {
            return _actions.GetUserDefaultExtension(userExtensionRequest);
        }

        [HttpGet("user/userInfoByIdentityId")]
        public Task<UserResponse> GetUserInfoByIdentityId([FromQuery] UserInfoByIdentityRequest userInfoByIdentityRequest)
        {
            return _actions.GetUserInfoByIdentityId(userInfoByIdentityRequest);
        }

        [HttpGet("user/userExtensions")]
        public Task<UserTelephonySystemResponse> GetUserExtensions([FromQuery] UserExtensionsRequest userExtenstionsRequest)
        {
            return _actions.GetUserExtensions(userExtenstionsRequest);
        }

        [HttpGet("user/userManagerExtension")]
        public Task<UserExtensionResponse> GetUserManagerExtension([FromQuery] UserManagerByExtensionRequest userManagerByExtensionRequest)
        {
            return _actions.GetUserManagerExtension(userManagerByExtensionRequest);
        }

        [HttpGet("identity/findByCustomerInfo")]
        public Task<IdentityResponse> GetIdentityByCustomerInfo([FromQuery] CustomerRequest customerRequest)
        {
            return _actions.GetIdentityByCustomerInfo(customerRequest);
        }

        [HttpGet("identity/findByPhoneNumber")]
        public Task<IdentityResponse> GetIdentityByPhoneNumber([FromQuery] IdentityByPhoneNumberRequest identityByPhoneNumberRequest)
        {
            return _actions.GetIdentityByPhoneNumber(identityByPhoneNumberRequest);
        }

        [HttpGet("identity/findByCustomerNumber")]
        public Task<IdentityResponse> GetIdentityByCustomerNumber([FromQuery] IdentityByCustomerNumberRequest identityByCustomerNumberRequest)
        {
            return _actions.GetIdentityByCustomerNumber(identityByCustomerNumberRequest);
        }

        [HttpGet("identity/balance")]
        public Task<IdentityBalanceResponse> GetIdentityBalance([FromQuery] CustomerRequest customerRequest)
        {
            return _actions.GetIdentityBalance(customerRequest);
        }

        [HttpPost("invoice/salesInvoice")]
        public Task<CreateInvoiceResponse> CreateInvoice([FromBody] CreateSalesInvoiceRequest createSalesInvoiceRequest)
        {
            return _actions.CreateInvoice(createSalesInvoiceRequest);
        }

        [HttpGet("contract/identityContractStatus")]
        public Task<IdentityContractStatusResponse> GetIdentityContractStatus([FromQuery] IdentityContractStatusRequest identityHasValidContractRequest)
        {
            return _actions.GetIdentityContractStatus(identityHasValidContractRequest);
        }

        [HttpPost("voting/queueOperatorVoting")]
        public Task<SubmitQueueOperatorVotingResponse> SubmitQueueOperatorVoting([FromBody] SubmitQueueOperatorVotingRequest submitQueueOperatorVotingRequest)
        {
            return _actions.SubmitQueueOperatorVoting(submitQueueOperatorVotingRequest);
        }

        [HttpPost("voting/voting")]
        public Task<SubmitVotingResponse> SubmitVoting([FromBody] SubmitVotingRequest submitVotingRequest)
        {
            return _actions.SubmitVoting(submitVotingRequest);
        }
    }
}
