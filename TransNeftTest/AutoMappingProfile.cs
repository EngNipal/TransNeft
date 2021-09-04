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
            // MeterPointService
            CreateMap<MeterPoint, MeterPointViewModel>();
            CreateMap<MeterPointViewModel, MeterPoint>();
            CreateMap<MeterPointDTO, MeterPoint>();
            
            // CalcMeterService
        }
    }
}
