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

namespace TransNeftTest.Controllers
{
    public class ApiController : Controller
    {
        private readonly OrganizationContext _context;
        private IMapper _mapper;
        private IElectricityMeterService _electricityMeterService;
        private ICurrentTransformerService _currentTransformerService;
        private IVoltageTransformerService _voltageTransformerService;


        public ApiController(OrganizationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _electricityMeterService = HttpContext.RequestServices.GetService<IElectricityMeterService>();
            _currentTransformerService = HttpContext.RequestServices.GetService<ICurrentTransformerService>();
            _voltageTransformerService = HttpContext.RequestServices.GetService<IVoltageTransformerService>();
        }

        [HttpGet]
        public async Task<ActionResult<ElectricityMeter>> AddNewElectricityMeter(int id, string number, DateTime checkDate)
        {
            var electricityMeter = new ElectricityMeter()
            {
                Id = id,
                Number = number,
                CheckDate = checkDate
            };

            _context.ElectricityMeters.Add(electricityMeter);
            await _context.SaveChangesAsync();

            return Created(number, electricityMeter); // ???
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMeterPoint()
        {

            var meterPoint;
            _context.MeterPoints.Add(meterPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMeterPoint), new { id = meterPoint.Id }, meterPoint);
        }

        [HttpGet("{year}")]
        public async Task<ActionResult<List<CalcMeter>>> GetCalcMetersByYear(int year)
        {
            return await _context.CalcMeters.Where(cm => cm.StartDate.Year ==  year).ToListAsync();
        }

        public async Task<List<ElectricityMeter>> GetElectricityMeterExpired()
        {
            return await _context.ElectricityMeters
                .Where(em => em.CheckDate < DateTime.Now)
                .ToListAsync();
        }

        [HttpGet("{consumerName}")]
        public async Task<List<VoltageTransformer>> GetVoltageTransformersByConsumer(string consumerName)
        {
            return await _context.VoltageTransformers
                .Where(vt => vt.MeterPoint.Consumer.Name == consumerName)
                .ToListAsync();
        }

        [HttpGet("{consumerName}")]
        public async Task<List<CurrentTransformer>> GetCurrentTransformersByConsumer(string consumerName)
        {
            return await _context.CurrentTransformers
                .Where(ct => ct.MeterPoint.Consumer.Name == consumerName)
                .ToListAsync();
        }
    }
}