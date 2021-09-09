using AutoMapper;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.ViewModels;

namespace TransNeftTest
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // CalcMeter
            CreateMap<CalcMeter, CalcMeterViewModel>();
            CreateMap<CalcMeterViewModel, CalcMeter>();
            CreateMap<CalcMeterDTO, CalcMeter>();

            // CurrentTransformer
            CreateMap<CurrentTransformer, CurrentTransformerViewModel>();
            CreateMap<CurrentTransformerViewModel, CurrentTransformer>();
            CreateMap<CurrentTransformerDTO, CurrentTransformer>();

            // DeliveryPoint
            CreateMap<DeliveryPoint, DeliveryPointViewModel>();
            CreateMap<DeliveryPointViewModel, DeliveryPoint>();
            CreateMap<DeliveryPointDTO, DeliveryPoint>();

            // Device
            CreateMap<Device, DeviceViewModel>();
            CreateMap<DeviceViewModel, Device>();
            CreateMap<DeviceDTO, Device>();

            // ElectricityMeter
            CreateMap<ElectricityMeter, ElectricityMeterViewModel>();
            CreateMap<ElectricityMeterViewModel, ElectricityMeter>();
            CreateMap<ElectricityMeterDTO, ElectricityMeter>();

            // EObject
            CreateMap<EObject, EObjectViewModel>();
            CreateMap<EObjectViewModel, EObject>();
            CreateMap<EObjectDTO, EObject>();

            // IdentifiedObject
            CreateMap<IdentifiedObjectDTO,  IdentifiedObjectViewModel>();
            CreateMap<IdentifiedObjectViewModel, IdentifiedObjectDTO>();
            CreateMap<IdentifiedObjectDTO, IdentifiedObject>();

            // MeterPoint
            CreateMap<MeterPoint, MeterPointViewModel>();
            CreateMap<MeterPointViewModel, MeterPoint>();
            CreateMap<MeterPointDTO, MeterPoint>();

            // Organization
            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<OrganizationViewModel, Organization>();
            CreateMap<OrganizationDTO, Organization>();

            // VoltageTransformer
            CreateMap<VoltageTransformer, VoltageTransformerViewModel>();
            CreateMap<VoltageTransformerViewModel, VoltageTransformer>();
            CreateMap<VoltageTransformerDTO, VoltageTransformer>();
        }
    }
}
