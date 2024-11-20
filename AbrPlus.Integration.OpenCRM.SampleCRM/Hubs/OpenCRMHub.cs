using AbrPlus.Integration.OpenCRM.Requests;
using Microsoft.AspNetCore.SignalR;

namespace AbrPlus.Cloud.Stream.Hubs
{
    public class OpenCRMHub : Hub
    {
        private readonly ILogger<OpenCRMHub> _logger;

        public OpenCRMHub(ILogger<OpenCRMHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }


    }
}