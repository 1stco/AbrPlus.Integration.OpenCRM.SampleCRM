using Microsoft.Extensions.DependencyInjection;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    public static class OpenCRMSampleActionsServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenCRMSampleActions(this IServiceCollection services)
        {
            services.AddScoped<ICallStoreActionsService, CallStoreActionsService>();
            services.AddScoped<ILookupSourceActionsService, LookupSourceActionsService>();
            services.AddScoped<IJsonRpcActionsService, JsonRpcActionsService>();

            return services;
        }
    }
}
