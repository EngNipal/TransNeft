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

        // GET api/<Controller>/<action>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerViewModel>>> FreeCurrentTransformers()
        {
            return await _apiService.GetFreeCurrentTransformers();
        }

        // GET api/<Controller>/<action>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<ElectricityMeterViewModel>>> FreeElectricityMeters()
        {
            return await _apiService.GetFreeElectricityMeters();
        }

        // GET api/<Controller>/<action>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerViewModel>>> FreeVoltageTransformers()
        {
            return await _apiService.GetFreeVoltageTransformers();
        }

        // POST api/<Controller>/meterPointDTO
        [HttpPost("{meterPointDTO}")]
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

        // GET api/<Controller>/2018
        [HttpGet("{year}")]
        public async Task<ActionResult<IEnumerable<CalcMeterViewModel>>> CalcMeters(int year)
        {
            if (year < _minYear)
            {
                return BadRequest($"Year must be greater than {_minYear}");
            }

            return await _apiService.GetCalcMetersByYear(year);
        }

        // GET api/<Controller>/<action>/eObjectDto
        [HttpGet("[action]/{eObjectDto}")]
        public async Task<ActionResult<IEnumerable<ElectricityMeterViewModel>>> EMExpired([FromBody]EObjectDTO eObjectDto)
        {
            var validRes = ValidateEObject(eObjectDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetEMExpiredByEObject(eObjectDto);
        }

        // GET api/<Controller>/<action>/eObjectDto
        [HttpGet("[action]/{eObjectDto}")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerViewModel>>> CTExpired(EObjectDTO eObjectDto)
        {
            var validRes = ValidateEObject(eObjectDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetCTExpiredByEObject(eObjectDto);
        }

        // GET api/<Controller>/<action>/eObjectDto
        [HttpGet("[action]/{eObjectDto}")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerViewModel>>> VTExpired(EObjectDTO eObjectDto)
        {
            var validRes = ValidateEObject(eObjectDto);
            if (!validRes.IsValid)
            {
                return BadRequest(validRes.Errors);
            }

            return await _apiService.GetVTExpiredByEObject(eObjectDto);
        }

        [NonAction]
        private ValidationResult ValidateEObject(EObjectDTO eObjectDto)
        {
            var validator = new EObjectValidator();
            return validator.Validate(eObjectDto);
        }
    }
}