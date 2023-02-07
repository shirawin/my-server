using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.Users;

namespace my_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IusersData _dbStore;

        public UsersController(MyDBContext context, IusersData dbStore)
        {

            _context = context;
            _dbStore = dbStore;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
            Console.WriteLine("5");

        }


        // GET: api/checkPassword/{email}/{password}
        [HttpGet]
        [Route("/api/Users/checkPassword/{email}/{password}")]
        public async Task<ActionResult<IEnumerable<User>>> isExsitsUser(string email, string password)
        {
            var result = await _dbStore.isExsitsUser(email, password);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("/api/createUser")]
        public async Task<ActionResult<IEnumerable<User>>> createUser(User user)
        {
            var result = await _dbStore.createUser(user);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Code)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Code }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Code == id);
        }

        [Route("logIn/")]
        [HttpPost]
        public int logIn(User user)
        {
            return 0;
        }
        [HttpGet]
        [Route("/api/GetSumOfHelpeds")]
        public async Task<ActionResult<IEnumerable<Travel>>> GetSumOfHelpeds()
        {
           var result = await _dbStore.sumOfHelpeds();
            return Ok(result);


        }
    }
}