using Microsoft.Extensions.DependencyInjection;
using TransNeftTest.Models;
using TransNeftTest.Repositories;
using TransNeftTest.Services;

namespace TransNeftTest
{
    public static class ServiceProviderExtensions
    {
        public static void AddServiceProfile(this IServiceCollection services)
        {
            services.AddScoped<IWebService, WebService>();

            services.AddTransient<IRepository<EObject>, SQLEObjectRepository>();
            services.AddTransient<IRepository<CalcMeter>, SQLCalcMeterRepository>();
            services.AddTransient<ICurrentTransformerRepository, SQLCurrentTransformerRepository>();
            services.AddTransient<IElectricityMeterRepository, SQLElectricityMeterRepository>();
            services.AddTransient<IRepository<MeterPoint>, SQLMeterPointRepository>();
            services.AddTransient<IVoltageTransformerRepository, SQLVoltageTransformerRepository>();
        }
    }
}