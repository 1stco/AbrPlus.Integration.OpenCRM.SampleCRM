using AbrPlus.Integration.OpenCRM.Requests;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Client.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        NewChannelSignalRClient _crmSampleSignalRClient;
        private async void Start_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Start.Enabled = false;
                await CloseConnection();

                _crmSampleSignalRClient = new NewChannelSignalRClient(async conf =>
                {
                    conf.HubUrl = textBox_URL.Text;
                    conf.IsAutomaticReconnect = checkBox_AutomaticReconnect.Checked;
                });

                _crmSampleSignalRClient.OnConnectionClosed += _crmSampleSignalRClient_OnConnectionClosed;
                _crmSampleSignalRClient.OnCallCreated += _crmSampleSignalRClient_OnCallCreated;
                _crmSampleSignalRClient.OnCallUpdated += _crmSampleSignalRClient_OnCallUpdated;
                _crmSampleSignalRClient.OnCallChannelCreated += _crmSampleSignalRClient_OnCallChannelCreated;
                _crmSampleSignalRClient.OnCallChannelUpdated += _crmSampleSignalRClient_OnCallChannelUpdated;
                _crmSampleSignalRClient.OnCallMerged += _crmSampleSignalRClient_OnCallMerged;
                _crmSampleSignalRClient.OnSubmitQueueOperatorVoting += _crmSampleSignalRClient_OnSubmitQueueOperatorVoting;
                _crmSampleSignalRClient.OnSubmitVoting += _crmSampleSignalRClient_OnSubmitVoting;

                await _crmSampleSignalRClient.InitialClient();
                await _crmSampleSignalRClient.StartConnection();

                btn_Stop.Enabled = true;
            }
            catch (Exception ex)
            {
                btn_Start.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _crmSampleSignalRClient_OnSubmitVoting(SubmitVotingRequest obj)
        {
            TryAddEvent(obj);
        }

        private void _crmSampleSignalRClient_OnSubmitQueueOperatorVoting(SubmitQueueOperatorVotingRequest obj)
        {
            TryAddEvent(obj);
        }

        private void _crmSampleSignalRClient_OnCallUpdated(CallUpdateRequest obj)
        {
            TryAddEvent(obj);
        }

        private void _crmSampleSignalRClient_OnCallCreated(CallCreateRequest obj)
        {
            TryAddEvent(obj);
        }

        private void _crmSampleSignalRClient_OnCallChannelCreated(CallChannelCreateRequest obj)
        {
            TryAddEvent(obj);
        }

        private void _crmSampleSignalRClient_OnCallChannelUpdated(CallChannelUpdateRequest obj)
        {
            TryAddEvent(obj);
        }

        private void _crmSampleSignalRClient_OnCallMerged(MergeCallRequest obj)
        {
            TryAddEvent(obj);
        }

        private void TryAddEvent(object obj)
        {
            try
            {
                if (listBox_Events.InvokeRequired)
                {
                    listBox_Events.Invoke(() =>
                    {
                        AddEvent(obj);
                    });
                }
                else
                {
                    AddEvent(obj);
                }
            }
            catch (Exception ex)
            {
                // log error
            }
        }

        private void AddEvent(object obj)
        {
            //check ChannelState is Ring or Ringing and peerName is your entension number
            listBox_Events.Items.Add(System.Text.Json.JsonSerializer.Serialize(obj));
        }

        private async Task CloseConnection()
        {
            if (_crmSampleSignalRClient != null && _crmSampleSignalRClient.IsConnected)
            {
                await _crmSampleSignalRClient.CloseConnection();
            }
        }

        private void _crmSampleSignalRClient_OnConnectionClosed()
        {
            btn_Start.Enabled = true;
            btn_Stop.Enabled = false;
        }

        private async void btn_Stop_Click(object sender, EventArgs e)
        {
            await CloseConnection();
        }
    }
}
