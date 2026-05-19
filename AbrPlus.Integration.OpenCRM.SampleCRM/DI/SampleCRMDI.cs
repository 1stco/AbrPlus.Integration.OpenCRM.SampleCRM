using AbrPlus.Cloud.Stream.IService;
using AbrPlus.Cloud.Stream.Services;
using AbrPlus.Integration.OpenCRM.SampleCRM.Controllers;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.DI
{
    public static class SampleCRMDI
    {
        public static void RegisterServices(this WebApplicationBuilder app)
        {
            app.Services.AddScoped<IOpenCRMHubService, OpenCRMHubService>();
            app.Services.AddScoped<IJsonRpcActionsService, JsonRpcActionsService>();
            app.Services.AddScoped<ICallStoreActionsService, CallStoreActionsService>();
            app.Services.AddScoped<ILookupSourceActionsService, LookupSourceActionsService>();
        }
    }
}
