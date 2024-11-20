namespace AbrPlus.Integration.OpenCRM.SampleCRM.Client.UI
{
    public class SignalRConfig
    {
        public SignalRConfig(string hubUrl)
        {
            HubUrl = hubUrl;
        }

        public string HubUrl { get; set; }
        public bool IsAutomaticReconnect { get; set; }
    }
}