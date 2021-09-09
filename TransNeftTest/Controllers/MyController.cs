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
        [HttpPost("{meterPointDTO}")]
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

        // GET api/<MyController>/eObjectDto
        [HttpGet("{eObjectDto}")]
        public async Task<ActionResult<List<ElectricityMeterViewModel>>> GetEMExpiredByEObject(EObjectDTO eObjectDto)
        {
            var validRes = ValidateEObject(eObjectDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetEMExpiredByEObject(eObjectDto);
        }

        // GET api/<MyController>/eObjectDto
        [HttpGet("{eObjectDto}")]
        public async Task<ActionResult<List<CurrentTransformerViewModel>>> GetCTExpiredByEObject(EObjectDTO eObjectDto)
        {
            var validRes = ValidateEObject(eObjectDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetCTExpiredByEObject(eObjectDto);
        }

        // GET api/<MyController>/eObjectDto
        [HttpGet("{eObjectDto}")]
        public async Task<ActionResult<List<VoltageTransformerViewModel>>> GetVTExpiredByEObject(EObjectDTO eObjectDto)
        {
            var validRes = ValidateEObject(eObjectDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetVTExpiredByEObject(eObjectDto);
        }

        private ValidationResult ValidateEObject(EObjectDTO eObjectDto)
        {
            var validator = new EObjectValidator();
            return validator.Validate(eObjectDto);
        }
    }
}