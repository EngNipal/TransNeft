using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
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

        [HttpPost]
        public async Task<IActionResult> CreateMeterPoint()
        {
            //var meterPoint;
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
        [HttpGet()]
        public async Task<ActionResult<List<ElectricityMeterViewModel>>> GetElectricityMeterExpired()
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!
            return await _apiService.GetElectricityMeterExpired();
        }

        // GET api/<MyController>/Рога_и_копыта
        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<VoltageTransformerViewModel>>> GetVoltageTransformersByConsumer(string consumerName)
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!
            return await _apiService.GetVoltageTransformersByConsumer(consumerName);
        }

        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<CurrentTransformerViewModel>>> GetCurrentTransformersByConsumer(string consumerName)
        {
            //TODO: ПРОВЕРКА ВХОДНЫХ ДАННЫХ!!!!
            return await _apiService.GetCurrentTransformersByConsumer(consumerName);
        }
    }
}