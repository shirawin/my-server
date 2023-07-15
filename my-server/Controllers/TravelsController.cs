using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.DTOS;
using Services.Travels;
using static my_server.EmailManager;
namespace my_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly ItravelsData _dbStore;
        private readonly EmailManager _email;


        public TravelsController(MyDBContext context, ItravelsData dbStore, EmailManager email)
        {
            _context = context;
            _dbStore = dbStore;
            _email = email;
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
        public async Task<ActionResult<TravelDto>> GetActiveTravels()
        {
            var travel = await _dbStore.GetActiveTravels();
            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }

        // כל המודעות של נעזר מסוים
        // GET: /api/GetTravelsByUser/{userId}
        [HttpGet]
        [Route("/api/GetTravelsByUser/{userId}")]
        public async Task<ActionResult<TravelDto>> GetTravelsByUser(int userId)
        {
            var travel = await _dbStore.GetTravelsByUser(userId);
            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }

        [HttpPost]
        [Route("/api/createTravel")]
        public async Task<ActionResult<IEnumerable<Travel>>> createTravel(Travel travel)
        {
            var List = await _dbStore.createTravel(travel);

            if (List == null)
            {
                return NotFound();
            }

            return Ok(List);
        }

        [HttpPost]
        [Route("/api/filterTravel")]
        public async Task<ActionResult<IEnumerable<Travel>>> filterTravel(FilterTravelsDto filterObj)
        {
            var List = await _dbStore.filterTravel(filterObj);

            if (List == null)
            {
                return NotFound();
            }

            return Ok(List);
        }
        [HttpPost]
        [Route("/api/filterTravelsByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<Travel>>> filterTravelsByUser(FilterTravelsDto filterObj, int userId)
        {
            var List = await _dbStore.filterTravelsByUser(filterObj, userId);

            if (List == null)
            {
                return NotFound();
            }

            return Ok(List);
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
        [HttpGet]
        [Route("/api/takeTravel/{travelID}/{volunteerID}")]
        public async Task<ActionResult<IEnumerable<bool>>> takeaTravel(int travelID, int volunteerID)
        {
            var result = await _dbStore.takeTravel(travelID, volunteerID);
            var volunteer = await _context.Users.FindAsync(volunteerID);
            var travel = await _context.Travels.FindAsync(travelID);
            if (travel != null)
            {
                var user = await _context.Users.FindAsync(travel.UserId);
                _email.EmailWithDetails(user, volunteer);

            }
            return Ok(result);


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
        [HttpGet]
        [Route("/api/GetSumOfTravels")]
        public async Task<ActionResult<IEnumerable<Travel>>> GetSumOfTravels()
        {
            var result = await _dbStore.sumOfTraves();
            return Ok(result);


        }
        [HttpPut]
        [Route("/api/closeTravel/{travelID}")]
        public async Task<IActionResult> closeTravel(int travelID)
        {
            var result = await _dbStore.closeTravel(travelID);
            if (result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
