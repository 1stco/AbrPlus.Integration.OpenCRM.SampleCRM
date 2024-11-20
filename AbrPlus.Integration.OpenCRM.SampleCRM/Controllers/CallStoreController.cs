using AbrPlus.Cloud.Stream.IService;
using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;
using AbrPlus.Integration.OpenCRM.SampleCRM.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    [ApiController]
    [Route("Call")]
    public class CallStoreController : ControllerBase
    {

        private readonly ILogger<CallStoreController> _logger;
        private readonly IOpenCRMHubService _openCRMHubService;

        public CallStoreController(ILogger<CallStoreController> logger, IOpenCRMHubService openCRMHubService)
        {
            _logger = logger;
            _openCRMHubService = openCRMHubService;
        }

        [HttpPost("CallCreated")]
        public async Task<CallCreateResponse> CallCreated([FromBody] CallCreateRequest callCreateRequest)
        {
            await _openCRMHubService.SendCallCreatedAsync(callCreateRequest);
            return callCreateRequest.ToResponse();
        }

        [HttpPost("CallUpdated")]
        public async Task<CallUpdateResponse> CallUpdated([FromBody] CallUpdateRequest callUpdateRequest)
        {
            await _openCRMHubService.SendCallUpdatedAsync(callUpdateRequest);
            return callUpdateRequest.ToResponse();
        }

        [HttpPost("CallChannelCreated")]
        public async Task<CallChannelCreateResponse> CallChannelCreated([FromBody] CallChannelCreateRequest callChannelCreateRequest)
        {
            await _openCRMHubService.SendCallChannelCreatedAsync(callChannelCreateRequest);
            return callChannelCreateRequest.ToResponse();
        }

        [HttpPost("CallChannelUpdated")]
        public async Task<CallChannelUpdateResponse> CallChannelUpdated([FromBody] CallChannelUpdateRequest callChannelUpdateRequest)
        {
            await _openCRMHubService.SendCallChannelUpdatedAsync(callChannelUpdateRequest);
            return callChannelUpdateRequest.ToResponse();
        }

        [HttpPost("MergeCall")]
        public async Task<MergeCallResponse> MergeCall([FromBody] MergeCallRequest mergeCallRequest)
        {
            await _openCRMHubService.SendMergeCallAsync(mergeCallRequest);
            return mergeCallRequest.ToResponse();
        }
    }
}
