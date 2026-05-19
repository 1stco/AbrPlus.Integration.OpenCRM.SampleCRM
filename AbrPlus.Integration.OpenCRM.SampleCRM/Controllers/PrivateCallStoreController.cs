using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    [ApiController]
    [Route("private/Call")]
    [Authorize]
    public class PrivateCallStoreController : ControllerBase
    {
        private readonly ICallStoreActionsService _actions;

        public PrivateCallStoreController(ICallStoreActionsService actions)
        {
            _actions = actions;
        }

        [HttpPost("CallCreated")]
        public Task<CallCreateResponse> CallCreated([FromBody] CallCreateRequest callCreateRequest)
        {
            return _actions.CallCreated(callCreateRequest);
        }

        [HttpPost("CallUpdated")]
        public Task<CallUpdateResponse> CallUpdated([FromBody] CallUpdateRequest callUpdateRequest)
        {
            return _actions.CallUpdated(callUpdateRequest);
        }

        [HttpPost("CallChannelCreated")]
        public Task<CallChannelCreateResponse> CallChannelCreated([FromBody] CallChannelCreateRequest callChannelCreateRequest)
        {
            return _actions.CallChannelCreated(callChannelCreateRequest);
        }

        [HttpPost("CallChannelUpdated")]
        public Task<CallChannelUpdateResponse> CallChannelUpdated([FromBody] CallChannelUpdateRequest callChannelUpdateRequest)
        {
            return _actions.CallChannelUpdated(callChannelUpdateRequest);
        }

        [HttpPost("MergeCall")]
        public Task<MergeCallResponse> MergeCall([FromBody] MergeCallRequest mergeCallRequest)
        {
            return _actions.MergeCall(mergeCallRequest);
        }
    }
}
