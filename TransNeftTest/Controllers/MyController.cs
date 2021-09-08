using AutoMapper;
using FluentValidation.Results;
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
using TransNeftTest.Validators;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : Controller
    {
        private IApiService _apiService { get; set; }
        public MyController(IApiService apiService) => _apiService = apiService;
        private int _minYear = 1900;

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

        // POST api/<MyController>
        [HttpPost]
        public async Task<IActionResult> CreateMeterPoint(MeterPointDTO meterPointDTO)
        {
            var validator = new MeterPointValidator();
            var validRes = validator.Validate(meterPointDTO);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            try
            {
                await _apiService.CreateMeterPoint(meterPointDTO);
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok(meterPointDTO);
        }

        // GET api/<MyController>/2018
        [HttpGet("{year}")]
        public async Task<ActionResult<List<CalcMeterViewModel>>> GetCalcMetersByYear(int year)
        {
            if (year < _minYear)
            {
                return BadRequest($"Year must be greater than {_minYear}");
            }

            return await _apiService.GetCalcMetersByYear(year);
        }

        // GET api/<MyController>/Рога_и_копыта
        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<ElectricityMeterViewModel>>> GetEMExpiredByConsumer(ConsumerDTO consumerDto)
        {
            var validRes = ValidateConsumer(consumerDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetEMExpiredByConsumer(consumerDto);
        }

        // GET api/<MyController>/Рога_и_копыта
        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<CurrentTransformerViewModel>>> GetCTExpiredByConsumer(ConsumerDTO consumerDto)
        {
            var validRes = ValidateConsumer(consumerDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetCTExpiredByConsumer(consumerDto);
        }

        // GET api/<MyController>/Рога_и_копыта
        [HttpGet("{consumerName}")]
        public async Task<ActionResult<List<VoltageTransformerViewModel>>> GetVTExpiredByConsumer(ConsumerDTO consumerDto)
        {
            var validRes = ValidateConsumer(consumerDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetVTExpiredByConsumer(consumerDto);
        }

        private ValidationResult ValidateConsumer (ConsumerDTO consumerDTO)
        {
            var validator = new ConsumerValidator();
            return validator.Validate(consumerDTO);
        }
    }
}