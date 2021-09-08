using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.Services;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : Controller
    {
        private IApiService _apiService { get; set; }
        public MyController(IApiService apiService) => _apiService = apiService;

        // GET api/<MyController>
        [HttpGet]
        public async Task<ActionResult<List<CurrentTransformerViewModel>>> GetFreeCurrentTransformers()
        {
            return await _apiService.GetFreeCurrentTransformers();
        }

        // GET api/<MyController>
        [HttpGet]
        public async Task<ActionResult<List<ElectricityMeterViewModel>>> GetFreeElectricityMeters()
        {
            return await _apiService.GetFreeElectricityMeters();
        }

        // GET api/<MyController>
        [HttpGet]
        public async Task<ActionResult<List<VoltageTransformerViewModel>>> GetFreeVoltageTransformers()
        {
            return await _apiService.GetFreeVoltageTransformers();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeterPoint(
            CalcMeterDTO calcMeterDTO,
            ElectricityMeterDTO electricityMeterDTO,
            VoltageTransformerDTO voltageTransformerDTO)
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!!
            var meterPointDTO = new MeterPointDTO()
            {
                CalcMeterId = calcMeterDTO.Id,
                ElictricityMeterId = electricityMeterDTO.Id,
                VoltageTransformerId = voltageTransformerDTO.Id
            };
            await _apiService.CreateMeterPoint(meterPointDTO);
            //_context.MeterPoints.Add(meterPoint);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetMeterPoint), new { id = meterPoint.Id }, meterPoint);
        }

        // GET api/<MyController>/2018
        [HttpGet("{year}")]
        public async Task<ActionResult<List<CalcMeterViewModel>>> GetCalcMetersByYear(int year)
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!!
            return await _apiService.GetCalcMetersByYear(year);
        }

        // GET api/<MyController>
        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<ElectricityMeterViewModel>>> GetEMExpiredByConsumer(ConsumerDTO consumerDto)
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!
            return await _apiService.GetEMExpiredByConsumer(consumerDto);
        }

        // GET api/<MyController>/Рога_и_копыта
        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<CurrentTransformerViewModel>>> GetCTExpiredByConsumer(ConsumerDTO consumerDto)
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!
            return await _apiService.GetCTExpiredByConsumer(consumerDto);
        }

        // GET api/<MyController>/Рога_и_копыта
        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<VoltageTransformerViewModel>>> GetVTExpiredByConsumer(ConsumerDTO consumerDto)
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!
            return await _apiService.GetVTExpiredByConsumer(consumerDto);
        }
    }
}