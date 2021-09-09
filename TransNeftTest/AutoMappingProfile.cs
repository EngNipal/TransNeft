using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            // EObject
            CreateMap<EObject, ConsumerViewModel>();
            CreateMap<ConsumerViewModel, EObject>();
            CreateMap<ConsumerDTO, EObject>();

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

            // Holding
            CreateMap<IdentifiedObject, HoldingViewModel>();
            CreateMap<HoldingViewModel, IdentifiedObject>();
            CreateMap<HoldingDTO, IdentifiedObject>();

            // MeterPoint
            CreateMap<MeterPoint, MeterPointViewModel>();
            CreateMap<MeterPointViewModel, MeterPoint>();
            CreateMap<MeterPointDTO, MeterPoint>();

            // Organization
            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<OrganizationViewModel, Organization>();
            CreateMap<OrganizationDTO, Organization>();

            // Subsidiary
            CreateMap<EObject, SubsidiaryViewModel>();
            CreateMap<SubsidiaryViewModel, EObject>();
            CreateMap<SubsidiaryDTO, EObject>();

            // VoltageTransformer
            CreateMap<VoltageTransformer, VoltageTransformerViewModel>();
            CreateMap<VoltageTransformerViewModel, VoltageTransformer>();
            CreateMap<VoltageTransformerDTO, VoltageTransformer>();
        }
    }
}
