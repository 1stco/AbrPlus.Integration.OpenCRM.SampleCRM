using AbrPlus.Integration.OpenCRM.Requests;
using Microsoft.AspNetCore.SignalR.Client;
namespace AbrPlus.Integration.OpenCRM.SampleCRM.Client.UI
{
    internal class NewChannelSignalRClient : BaseCrmSampleSignalRClient
    {
        public event Action<CallChannelCreateRequest> OnCallChannelCreated;
        public event Action OnConnectionClosed;
        public NewChannelSignalRClient(Func<SignalRConfig, Task> signalRClientConfigure) : base(signalRClientConfigure)
        {
        }

        public async Task CloseConnection()
        {
            await connection.StopAsync();
        }
        public async Task StartConnection()
        {
            await connection.StartAsync();
        }

        public bool IsConnected => (connection?.State ?? HubConnectionState.Disconnected) == HubConnectionState.Connected;

        protected override Task Connection_Closed(Exception arg)
        {
            if (OnConnectionClosed != null)
            {
                OnConnectionClosed();
            }
            return base.Connection_Closed(arg);
        }

        protected override Task CallChannelCreated(CallChannelCreateRequest request)
        {
            if (OnCallChannelCreated != null)
            {
                OnCallChannelCreated(request);
            }
            return base.CallChannelCreated(request);
        }

    }
}
