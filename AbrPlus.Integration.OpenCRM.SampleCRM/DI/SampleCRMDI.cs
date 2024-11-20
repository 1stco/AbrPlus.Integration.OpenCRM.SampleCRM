using AbrPlus.Cloud.Stream.IService;
using AbrPlus.Cloud.Stream.Services;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.DI
{
    public static class SampleCRMDI
    {
        public static void RegisterServices(this WebApplicationBuilder app)
        {
            app.Services.AddScoped<IOpenCRMHubService, OpenCRMHubService>();
        }
    }
}
