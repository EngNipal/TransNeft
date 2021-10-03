using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Services;
using TransNeftTest.Validators;

namespace TransNeftTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : Controller
    {
        private IWebService _apiService { get; set; }
        public WebController(IWebService apiService) => _apiService = apiService;

        private const int _minYear = 1950;

        // GET api/<Controller>/CurrentTransformers/Free
        [HttpGet("CurrentTransformers/Free")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerDto>>> GetFreeCurrentTransformers()
        {
            return Ok(await _apiService.GetFreeCurrentTransformers());
        }

        // GET api/<Controller>/ElectricityMeters/Free
        [HttpGet("ElectricityMeters/Free")]
        public async Task<ActionResult<IEnumerable<ElectricityMeterDto>>> GetFreeElectricityMeters()
        {
            return Ok(await _apiService.GetFreeElectricityMeters());
        }

        // GET api/<Controller>/VoltageTransformers/Free
        [HttpGet("VoltageTransformers/Free")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerDto>>> GetFreeVoltageTransformers()
        {
            return Ok(await _apiService.GetFreeVoltageTransformers());
        }

        // POST api/<Controller>/MeterPoint
        [HttpPost("MeterPoint")]
        public async Task<IActionResult> CreateMeterPoint([FromBody]MeterPointDto meterPointDto)
        {
            var validator = new MeterPointValidator();
            var validRes = validator.Validate(meterPointDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            try
            {
                await _apiService.CreateMeterPoint(meterPointDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(meterPointDto);
        }

        // GET api/<Controller>/CalcMeters/2018
        [HttpGet("CalcMeters/{year}")]
        public async Task<ActionResult<IEnumerable<CalcMeterDto>>> GetCalcMetersByYear(int year)
        {
            if (year < _minYear)
            {
                return BadRequest($"Year must be greater than {_minYear}");
            }

            return Ok(await _apiService.GetCalcMetersByYear(year));
        }

        // GET api/<Controller>/EObjects/{Id}/ElectricityMeters/Expired
        [HttpGet("EObjects/{Id}/ElectricityMeters/Expired")]
        public async Task<ActionResult<IEnumerable<ElectricityMeterDto>>> GetElectricityMetersExpired(int Id)
        {
            if (!await _apiService.EObjectExists(Id))
            {
                return BadRequest($"Wrong {nameof(Id)}");
            }

            return Ok(await _apiService.GetElectricityMeterExpiredByEObject(Id));
        }

        // GET api/<Controller>/EObjects/{Id}/CurrentTransformers/Expired
        [HttpGet("EObjects/{Id}/CurrentTransformers/Expired")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerDto>>> GetCurrentTransformersExpired(int Id)
        {
            if (!await _apiService.EObjectExists(Id))
            {
                return BadRequest($"Wrong {nameof(Id)}");
            }

            return Ok(await _apiService.GetCurrentTransformerExpiredByEObject(Id));
        }

        // GET api/<Controller>/EObjects/{Id}/VoltageTransformers/Expired
        [HttpGet("EObjects/{Id}/VoltageTransformers/Expired")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerDto>>> GetVoltageTransformersExpired(int Id)
        {
            if (!await _apiService.EObjectExists(Id))
            {
                return BadRequest($"Wrong {nameof(Id)}");
            }

            return Ok(await _apiService.GetVoltageTransformerExpiredByEObject(Id));
        }
    }
}