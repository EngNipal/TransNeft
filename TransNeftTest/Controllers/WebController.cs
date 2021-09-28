using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Services;
using TransNeftTest.Validators;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : Controller
    {
        private IWebService _apiService { get; set; }
        public WebController(IWebService apiService) => _apiService = apiService;
        private const int _minYear = 1900;

        // GET api/<Controller>/CurrentTransformers/Free
        [HttpGet("CurrentTransformers/Free")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerDTO>>> GetFreeCurrentTransformers()
        {
            return Ok(await _apiService.GetFreeCurrentTransformers());
        }

        // GET api/<Controller>/ElectricityMeters/Free
        [HttpGet("ElectricityMeters/Free")]
        public async Task<ActionResult<IEnumerable<ElectricityMeterDTO>>> GetFreeElectricityMeters()
        {
            return Ok(await _apiService.GetFreeElectricityMeters());
        }

        // GET api/<Controller>/VoltageTransformers/Free
        [HttpGet("VoltageTransformers/Free")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerDTO>>> GetFreeVoltageTransformers()
        {
            return Ok(await _apiService.GetFreeVoltageTransformers());
        }

        // POST api/<Controller>/MeterPoint
        [HttpPost("MeterPoint")]
        public async Task<IActionResult> CreateMeterPoint([FromBody]MeterPointDTO meterPointDTO)
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
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok(meterPointDTO);
        }

        // GET api/<Controller>/CalcMeters/2018
        [HttpGet("CalcMeters/{year}")]
        public async Task<ActionResult<IEnumerable<CalcMeterDTO>>> GetCalcMetersByYear(int year)
        {
            if (year < _minYear)
            {
                return BadRequest($"Year must be greater than {_minYear}");
            }

            return Ok(await _apiService.GetCalcMetersByYear(year));
        }

        // GET api/<Controller>/EObjects/{Id}/ElectricityMeters/Expired
        [HttpGet("EObjects/{Id}/ElectricityMeters/Expired")]
        public async Task<ActionResult<IEnumerable<ElectricityMeterDTO>>> GetElectricityMetersExpired(int Id)
        {
            if (!await _apiService.EObjectExists(Id))
            {
                return BadRequest($"Wrong {nameof(Id)}");
            }

            return Ok(await _apiService.GetEMExpiredByEObject(Id));
        }

        // GET api/<Controller>/EObjects/{Id}/CurrentTransformers/Expired
        [HttpGet("EObjects/{Id}/CurrentTransformers/Expired")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerDTO>>> GetCurrentTransformersExpired(int Id)
        {
            if (!await _apiService.EObjectExists(Id))
            {
                return BadRequest($"Wrong {nameof(Id)}");
            }

            return Ok(await _apiService.GetCTExpiredByEObject(Id));
        }

        // GET api/<Controller>/EObjects/{Id}/VoltageTransformers/Expired
        [HttpGet("EObjects/{Id}/VoltageTransformers/Expired")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerDTO>>> GetVoltageTransformersExpired(int Id)
        {
            if (!await _apiService.EObjectExists(Id))
            {
                return BadRequest($"Wrong {nameof(Id)}");
            }

            return Ok(await _apiService.GetVTExpiredByEObject(Id));
        }
    }
}