using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.Travels;
using Services.Volunteers;
namespace my_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IvolunteerData _dbStore;
        public VolunteersController(MyDBContext context, IvolunteerData dbStore)
        {
            _context = context;
            _dbStore = dbStore;
        }

        [HttpGet]
        [Route("/api/GetSumOfVolunteers")]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetSumOfVolunteers()
        {
            var result = await _dbStore.sumOfVolunteers();
            return Ok(result);

        }
    }
}
