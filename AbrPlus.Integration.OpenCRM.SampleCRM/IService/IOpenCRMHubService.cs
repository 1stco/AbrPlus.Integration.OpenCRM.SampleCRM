using AbrPlus.Integration.OpenCRM.Requests;

namespace AbrPlus.Cloud.Stream.IService
{
    public interface IOpenCRMHubService
    {
        Task SendCallChannelCreatedAsync(CallChannelCreateRequest callChannelCreateRequest);
        Task SendCallChannelUpdatedAsync(CallChannelUpdateRequest callChannelUpdateRequest);
        Task SendCallCreatedAsync(CallCreateRequest request);
        Task SendCallUpdatedAsync(CallUpdateRequest callUpdateRequest);
        Task SendMergeCallAsync(MergeCallRequest mergeCallRequest);
    }
}