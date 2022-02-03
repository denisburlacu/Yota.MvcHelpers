using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Yota.MvcHelpers.Iis
{
    public static class IisConfigurator
    {
        public static void AddIis(this IServiceCollection services)
        {
            //This is required for RestSharp as he have some issues related to this
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            services.Configure<IISServerOptions>(options =>
                                                 {
                                                     options.AutomaticAuthentication = false;
                                                 });
            services.Configure<IISOptions>(options =>
                                           {
                                               options.ForwardClientCertificate = false;
                                               options.AutomaticAuthentication = false;
                                           });
        }
    }
}