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
            services.AddScoped<IApiService, ApiService>();
            
            services.AddScoped<IRepository<CalcMeter>, SQLCalcMeterRepository>();
            services.AddScoped<IRepository<CurrentTransformer>, SQLCurrentTransformerRepository>();
            services.AddScoped<IRepository<ElectricityMeter>, SQLElectricityMeterRepository>();
            services.AddScoped<IRepository<MeterPoint>, SQLMeterPointRepository>();
            services.AddScoped<IRepository<VoltageTransformer>, SQLVoltageTransformerRepository>();
        }
    }
}