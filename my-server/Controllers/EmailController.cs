using Microsoft.AspNetCore.Mvc;

namespace my_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly EmailManager _emailManager;

        public EmailController(EmailManager emailManager)
        {
            _emailManager = emailManager;
        }
        [HttpGet]
        public IActionResult Post()
        {
            _emailManager.SendEmail("shv1891@gmail.com", "שירה");
            return Ok();
        }
    }
}
