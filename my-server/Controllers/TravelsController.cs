using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.Travels;


namespace my_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly ItravelsData _dbStore;

        public TravelsController(MyDBContext context, ItravelsData dbStore)
        {
            _context = context;
            _dbStore= dbStore;
        }

        // GET: api/Travels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travel>>> GetTravels()
        {
            return await _context.Travels.ToListAsync(); 
        }

        //כל המודעות הפעילות - עבור התנדבים
        // GET: api/GetActiveTravels
        [HttpGet]
        [Route("/api/GetActiveTravels")]
        public async Task<ActionResult<IEnumerable<Travel>>> GetActiveTravels()
        {
            var travel = await _context.Travels.Where(t => t.Status == 1).ToListAsync();
            if (travel == null)
            {
                return NotFound();
            }

            return travel;

            //var result = await _dbStore.GetActiveTravels();
            //if (result != null)
            //{
            //    return Ok(result);
            //}
            //return BadRequest();
        }

        // כל המודעות של נעזר מסוים
        // GET: /api/GetTravelsByUser/{userId}
        [HttpGet]
        [Route("/api/GetTravelsByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<Travel>>> GetTravelsByUser(int userId)
        {
            var travel = await _context.Travels.Where(t => t.UserId == userId).ToListAsync();
            if (travel == null)
            {
                return NotFound();
            }

            return travel;
        }

        // GET: api/Travels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Travel>> GetTravel(int id)
        {
            var travel = await _context.Travels.FindAsync(id);
            if (travel == null)
            {
                return NotFound();
            }

            return travel;
        }

        // PUT: api/Travels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravel(int id, Travel travel)
        {
            if (id != travel.TravelId)
            {
                return BadRequest();
            }

            _context.Entry(travel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelExists(id))
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

        // POST: api/Travels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Travel>> PostTravel(Travel travel)
        {
            _context.Travels.Add(travel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravel", new { id = travel.TravelId }, travel);
        }

        // DELETE: api/Travels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravel(int id)
        {
            var travel = await _context.Travels.FindAsync(id);
            if (travel == null)
            {
                return NotFound();
            }

            _context.Travels.Remove(travel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelExists(int id)
        {
            return _context.Travels.Any(e => e.TravelId == id);
        }
    }
}
