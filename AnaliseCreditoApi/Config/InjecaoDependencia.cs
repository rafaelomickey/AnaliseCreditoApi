using AnaliseCreditoApi.Interfaces.Services;
using AnaliseCreditoApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AnaliseCreditoApi.Config
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddTransient<IAnaliseCreditoService, AnaliseCreditoService>();
            return services;
        }
    }
}
