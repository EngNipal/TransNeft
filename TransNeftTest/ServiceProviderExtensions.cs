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
            services.AddScoped<ICalcMeterService, CalcMeterService>();
            services.AddScoped<IConsumerService, ConsumerService>();
            services.AddScoped<ICurrentTransformerService, CurrentTransformerService>();
            services.AddScoped<IDeliveryPointService, DeliveryPointService>();
            services.AddScoped<IDeviceServise, DeviceServise>();
            services.AddScoped<IElectricityMeterService, ElectricityMeterService>();
            services.AddScoped<IHoldingService, HoldingService>();
            services.AddScoped<IMeterPointService, MeterPointService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<ISubsidiaryService, SubsidiaryService>();
            services.AddScoped<IVoltageTransformerService, VoltageTransformerService>();
            
            services.AddScoped<IRepository<CalcMeter>, SQLCalcMeterRepository>();
            services.AddScoped<IRepository<Consumer>, SQLConsumerRepository>();
            services.AddScoped<IRepository<CurrentTransformer>, SQLCurrentTransformerRepository>();
            services.AddScoped<IRepository<DeliveryPoint>, SQLDeliveryPointRepository>();
            services.AddScoped<IRepository<Device>, SQLDeviceRepository>();
            services.AddScoped<IRepository<ElectricityMeter>, SQLElectricityMeterRepository>();
            services.AddScoped<IRepository<IdentifiedObject>, SQLHoldingRepository>();
            services.AddScoped<IRepository<MeterPoint>, SQLMeterPointRepository>();
            services.AddScoped<IRepository<Organization>, SQLOrganizationRepository>();
            services.AddScoped<IRepository<EObject>, SQLSubsidiaryRepository>();
            services.AddScoped<IRepository<VoltageTransformer>, SQLVoltageTransformerRepository>();
        }
    }
}