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
            
            services.AddTransient<IRepository<CalcMeter>, SQLCalcMeterRepository>();
            services.AddTransient<IRepository<CurrentTransformer>, SQLCurrentTransformerRepository>();
            services.AddTransient<IRepository<ElectricityMeter>, SQLElectricityMeterRepository>();
            services.AddTransient<IRepository<MeterPoint>, SQLMeterPointRepository>();
            services.AddTransient<IRepository<VoltageTransformer>, SQLVoltageTransformerRepository>();
        }
    }
}