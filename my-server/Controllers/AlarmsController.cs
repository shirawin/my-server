using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;

namespace my_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public AlarmsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Alarms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alarm>>> GetAlarms()
        {
          if (_context.Alarms == null)
          {
              return NotFound();
          }
            return await _context.Alarms.ToListAsync();
        }

        // GET: api/Alarms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alarm>> GetAlarm(int id)
        {
          if (_context.Alarms == null)
          {
              return NotFound();
          }
            var alarm = await _context.Alarms.FindAsync(id);

            if (alarm == null)
            {
                return NotFound();
            }

            return alarm;
        }

        // PUT: api/Alarms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlarm(int id, Alarm alarm)
        {
            if (id != alarm.Codealarm)
            {
                return BadRequest();
            }

            _context.Entry(alarm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlarmExists(id))
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

        // POST: api/Alarms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alarm>> PostAlarm(Alarm alarm)
        {
          if (_context.Alarms == null)
          {
              return Problem("Entity set 'MyDBContext.Alarms'  is null.");
          }
            _context.Alarms.Add(alarm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlarm", new { id = alarm.Codealarm }, alarm);
        }

        // DELETE: api/Alarms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlarm(int id)
        {
            if (_context.Alarms == null)
            {
                return NotFound();
            }
            var alarm = await _context.Alarms.FindAsync(id);
            if (alarm == null)
            {
                return NotFound();
            }

            _context.Alarms.Remove(alarm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlarmExists(int id)
        {
            return (_context.Alarms?.Any(e => e.Codealarm == id)).GetValueOrDefault();
        }
    }
}
