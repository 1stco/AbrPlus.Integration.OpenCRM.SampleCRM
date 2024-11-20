using AbrPlus.Integration.OpenCRM.Requests;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Client.UI
{
    public abstract class BaseCrmSampleSignalRClient
    {
        private readonly Func<SignalRConfig, Task> _signalRClientConfigure;
        private readonly SignalRConfig _connecionConf;
        /// <summary>
        /// Hub Connection
        /// </summary>
        protected HubConnection connection;

        /// <summary>
        /// Get connection configuration
        /// </summary>
        protected SignalRConfig ConnectionConfig => _connecionConf;

        public BaseCrmSampleSignalRClient(Func<SignalRConfig, Task> signalRClientConfigure)
        {
            _signalRClientConfigure = signalRClientConfigure;
            _connecionConf = new SignalRConfig("https://localhost:7074/OpenCRMHub");
        }

        public async Task InitialClient()
        {
            await _signalRClientConfigure(_connecionConf);

            var hubConnectionBuilder = new HubConnectionBuilder();

            hubConnectionBuilder.WithUrl(_connecionConf.HubUrl);

            if (_connecionConf.IsAutomaticReconnect)
            {
                hubConnectionBuilder.WithAutomaticReconnect();
            }

            connection = hubConnectionBuilder.Build();

            connection.Closed += Connection_Closed;
            connection.Reconnecting += Connection_Reconnecting;
            connection.Reconnected += Connection_Reconnected;

            InternalBindEvents();
        }

        protected virtual void InternalBindEvents()
        {
            connection.On<CallChannelCreateRequest>("CallChannelCreated", CallChannelCreated);
            connection.On<CallChannelUpdateRequest>("CallChannelUpdated", CallChannelUpdated);
            connection.On<CallCreateRequest>("CallCreated", CallCreated);
            connection.On<CallUpdateRequest>("CallUpdated", CallUpdated);
            connection.On<MergeCallRequest>("MergeCall", MergeCall);
        }

        protected virtual Task Connection_Reconnected(string arg)
        {
            Debug.Assert(connection.State == HubConnectionState.Connected);

            // Notify users the connection was reestablished.
            // Start dequeuing messages queued while reconnecting if any.

            return Task.CompletedTask;
        }

        protected virtual Task Connection_Reconnecting(Exception arg)
        {
            Debug.Assert(connection.State == HubConnectionState.Reconnecting);

            // Notify users the connection was lost and the client is reconnecting.
            // Start queuing or dropping messages.

            return Task.CompletedTask;
        }

        protected virtual Task Connection_Closed(Exception arg)
        {
            Debug.Assert(connection.State == HubConnectionState.Disconnected);

            // Notify users the connection has been closed or manually try to restart the connection.

            return Task.CompletedTask;
        }

        /// <summary>
        /// Occurs when a new channel is created
        /// </summary>
        /// <param name="request">new channel request model</param>
        /// <returns></returns>
        protected virtual Task CallChannelCreated(CallChannelCreateRequest request)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// Occurs when a new channel is updated
        /// </summary>
        /// <param name="request">updated channel request model</param>
        /// <returns></returns>
        protected virtual Task CallChannelUpdated(CallChannelUpdateRequest request)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// Occurs when a new call is created
        /// </summary>
        /// <param name="request">new channel request model</param>
        /// <returns></returns>
        protected virtual Task CallCreated(CallCreateRequest request)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// Occurs when a call is updated
        /// </summary>
        /// <param name="request">new channel request model</param>
        /// <returns></returns>
        protected virtual Task CallUpdated(CallUpdateRequest request)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// Occurs when two call merge together
        /// </summary>
        /// <param name="request">new channel request model</param>
        /// <returns></returns>
        protected virtual Task MergeCall(MergeCallRequest request)
        {
            return Task.CompletedTask;
        }
    }
}