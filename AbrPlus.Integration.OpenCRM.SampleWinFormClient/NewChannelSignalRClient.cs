using AbrPlus.Integration.OpenCRM.Requests;
using Microsoft.AspNetCore.SignalR.Client;
namespace AbrPlus.Integration.OpenCRM.SampleCRM.Client.UI
{
    internal class NewChannelSignalRClient : BaseCrmSampleSignalRClient
    {
        public event Action<CallCreateRequest> OnCallCreated;
        public event Action<CallUpdateRequest> OnCallUpdated;
        public event Action<CallChannelCreateRequest> OnCallChannelCreated;
        public event Action<CallChannelUpdateRequest> OnCallChannelUpdated;
        public event Action<MergeCallRequest> OnCallMerged;
        public event Action<SubmitQueueOperatorVotingRequest> OnSubmitQueueOperatorVoting;
        public event Action<SubmitVotingRequest> OnSubmitVoting;
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

        protected override Task CallCreated(CallCreateRequest request)
        {
            OnCallCreated?.Invoke(request);
            return base.CallCreated(request);
        }
        protected override Task CallUpdated(CallUpdateRequest request)
        {
            OnCallUpdated?.Invoke(request);
            return base.CallUpdated(request);
        }

        protected override Task CallChannelCreated(CallChannelCreateRequest request)
        {
            OnCallChannelCreated?.Invoke(request);
            return base.CallChannelCreated(request);
        }

        protected override Task CallChannelUpdated(CallChannelUpdateRequest request)
        {
            OnCallChannelUpdated?.Invoke(request);
            return base.CallChannelUpdated(request);
        }

        protected override Task MergeCall(MergeCallRequest request)
        {
            OnCallMerged?.Invoke(request);
            return base.MergeCall(request);
        }

        protected override Task SubmitQueueOperatorVoting(SubmitQueueOperatorVotingRequest request)
        {
            OnSubmitQueueOperatorVoting?.Invoke(request);
            return base.SubmitQueueOperatorVoting(request);
        }

        protected override Task SubmitVoting(SubmitVotingRequest request)
        {
            OnSubmitVoting?.Invoke(request);
            return base.SubmitVoting(request);
        }
    }
}
