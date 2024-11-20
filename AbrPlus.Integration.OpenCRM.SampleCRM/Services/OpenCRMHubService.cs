using AbrPlus.Cloud.Stream.Hubs;
using AbrPlus.Cloud.Stream.IService;
using AbrPlus.Integration.OpenCRM.Requests;
using Microsoft.AspNetCore.SignalR;

namespace AbrPlus.Cloud.Stream.Services
{
    public class OpenCRMHubService : IOpenCRMHubService
    {
        private readonly IHubContext<OpenCRMHub> _streamHub;
        private readonly ILogger<OpenCRMHubService> _logger;

        public OpenCRMHubService(
            IHubContext<OpenCRMHub> streamHub,
            ILogger<OpenCRMHubService> logger)
        {
            _streamHub = streamHub;
            _logger = logger;
        }

        public async Task SendCallChannelCreatedAsync(CallChannelCreateRequest request)
        {
            try
            {
                await _streamHub.Clients.All.SendAsync("CallChannelCreated", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SendCallChannelCreatedAsync has error. CallChannelCreateRequest is {@request}", request);
                throw;
            }
        }

        public async Task SendCallChannelUpdatedAsync(CallChannelUpdateRequest request)
        {
            try
            {
                await _streamHub.Clients.All.SendAsync("CallChannelUpdated", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SendCallChannelUpdatedAsync has error. CallCreateRequest is {@request}", request);
                throw;
            }
        }

        public async Task SendCallCreatedAsync(CallCreateRequest request)
        {
            try
            {
                await _streamHub.Clients.All.SendAsync("CallCreated", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SendCallCreatedAsync has error. CallCreateRequest is {@request}", request);
                throw;
            }
        }

        public async Task SendCallUpdatedAsync(CallUpdateRequest request)
        {
            try
            {
                await _streamHub.Clients.All.SendAsync("CallUpdated", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SendCallUpdatedAsync has error. CallUpdateRequest is {@request}", request);
                throw;
            }
        }

        public async Task SendMergeCallAsync(MergeCallRequest request)
        {
            try
            {
                await _streamHub.Clients.All.SendAsync("MergeCall", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SendMergeCallAsync has error. MergeCallRequest is {@request}", request);
                throw;
            }
        }
    }
}