using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransNeftTest;
using TransNeftTest.Models;

namespace TransNeftTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterPointController : ControllerBase
    {
        private readonly OrganizationContext _context;

        public MeterPointController(OrganizationContext context)
        {
            _context = context;
        }

        // GET: api/MeterPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeterPoint>>> GetMeterPoints()
        {
            return await _context.MeterPoints.ToListAsync();
        }

        // GET: api/MeterPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeterPoint>> GetMeterPoint(int id)
        {
            var meterPoint = await _context.MeterPoints.FindAsync(id);

            if (meterPoint == null)
            {
                return NotFound();
            }

            return meterPoint;
        }

        // PUT: api/MeterPoints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeterPoint(int id, MeterPoint meterPoint)
        {
            if (id != meterPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(meterPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeterPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MeterPoints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MeterPoint>> PostMeterPoint(MeterPoint meterPoint)
        {
            _context.MeterPoints.Add(meterPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMeterPoint), new { id = meterPoint.Id }, meterPoint);
        }

        // DELETE: api/MeterPoints/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMeterPoint(int id)
        //{
        //    var meterPoint = await _context.MeterPoints.FindAsync(id);
        //    if (meterPoint == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MeterPoints.Remove(meterPoint);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool MeterPointExists(int id)
        {
            return _context.MeterPoints.Any(e => e.Id == id);
        }
    }
}
