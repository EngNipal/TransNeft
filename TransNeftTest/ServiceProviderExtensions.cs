using Microsoft.Extensions.DependencyInjection;
using TransNeftTest.DTOModels;
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
            services.AddTransient<IRepository<CurrentTransformer>, SQLCurrentTransformerRepository>();
            services.AddTransient<IEMRepository, SQLElectricityMeterRepository>();
            services.AddTransient<IRepository<MeterPointDTO>, SQLMeterPointRepository>();
            services.AddTransient<IRepository<VoltageTransformer>, SQLVoltageTransformerRepository>();
        }
    }
}