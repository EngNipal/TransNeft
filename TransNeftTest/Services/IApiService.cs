﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface IApiService
    {
        public Task<ActionResult<List<ElectricityMeterViewModel>>> GetFreeElectricityMeters();
        public Task<ActionResult<List<CurrentTransformerViewModel>>> GetFreeCurrentTransformers();
        public Task<ActionResult<List<VoltageTransformerViewModel>>> GetFreeVoltageTransformers();

        public Task CreateMeterPoint(MeterPointDTO meterPointDto);
        public Task<List<CalcMeterViewModel>> GetCalcMetersByYear(int year);
        public Task<List<ElectricityMeterViewModel>> GetEMExpiredByConsumer(ConsumerDTO consumerDto);
        public Task<List<CurrentTransformerViewModel>> GetCTExpiredByConsumer(ConsumerDTO consumerDto);
        public Task<List<VoltageTransformerViewModel>> GetVTExpiredByConsumer(ConsumerDTO consumerDto);
    }
}