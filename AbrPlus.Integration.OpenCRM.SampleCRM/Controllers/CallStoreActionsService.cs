using AbrPlus.Cloud.Stream.IService;
using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;
using AbrPlus.Integration.OpenCRM.SampleCRM.Mappers;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    public interface ICallStoreActionsService
    {
        Task<CallCreateResponse> CallCreated(CallCreateRequest callCreateRequest);
        Task<CallUpdateResponse> CallUpdated(CallUpdateRequest callUpdateRequest);
        Task<CallChannelCreateResponse> CallChannelCreated(CallChannelCreateRequest callChannelCreateRequest);
        Task<CallChannelUpdateResponse> CallChannelUpdated(CallChannelUpdateRequest callChannelUpdateRequest);
        Task<MergeCallResponse> MergeCall(MergeCallRequest mergeCallRequest);
    }

    public class CallStoreActionsService : ICallStoreActionsService
    {
        private readonly ILogger<CallStoreActionsService> _logger;
        private readonly IOpenCRMHubService _openCRMHubService;

        public CallStoreActionsService(ILogger<CallStoreActionsService> logger, IOpenCRMHubService openCRMHubService)
        {
            _logger = logger;
            _openCRMHubService = openCRMHubService;
        }

        public async Task<CallCreateResponse> CallCreated(CallCreateRequest callCreateRequest)
        {
            _logger.LogInformation("REST /Call/CallCreated called. Request: {request}", LogJsonSerializer.Serialize(callCreateRequest));
            await _openCRMHubService.SendCallCreatedAsync(callCreateRequest);
            return callCreateRequest.ToResponse();
        }

        public async Task<CallUpdateResponse> CallUpdated(CallUpdateRequest callUpdateRequest)
        {
            _logger.LogInformation("REST /Call/CallUpdated called. Request: {request}", LogJsonSerializer.Serialize(callUpdateRequest));
            await _openCRMHubService.SendCallUpdatedAsync(callUpdateRequest);
            return callUpdateRequest.ToResponse();
        }

        public async Task<CallChannelCreateResponse> CallChannelCreated(CallChannelCreateRequest callChannelCreateRequest)
        {
            _logger.LogInformation("REST /Call/CallChannelCreated called. Request: {request}", LogJsonSerializer.Serialize(callChannelCreateRequest));
            await _openCRMHubService.SendCallChannelCreatedAsync(callChannelCreateRequest);
            return callChannelCreateRequest.ToResponse();
        }

        public async Task<CallChannelUpdateResponse> CallChannelUpdated(CallChannelUpdateRequest callChannelUpdateRequest)
        {
            _logger.LogInformation("REST /Call/CallChannelUpdated called. Request: {request}", LogJsonSerializer.Serialize(callChannelUpdateRequest));
            await _openCRMHubService.SendCallChannelUpdatedAsync(callChannelUpdateRequest);
            return callChannelUpdateRequest.ToResponse();
        }

        public async Task<MergeCallResponse> MergeCall(MergeCallRequest mergeCallRequest)
        {
            _logger.LogInformation("REST /Call/MergeCall called. Request: {request}", LogJsonSerializer.Serialize(mergeCallRequest));
            await _openCRMHubService.SendMergeCallAsync(mergeCallRequest);
            return mergeCallRequest.ToResponse();
        }
    }
}
