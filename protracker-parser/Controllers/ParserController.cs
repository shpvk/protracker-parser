using Microsoft.AspNetCore.Mvc;
using protracker_parser.Models;
using protracker_parser.Services;

namespace protracker_parser.Controllers
{
    [Route("api/[controller]")]
    public class ParserController : ControllerBase
    {

        private ParserService ParserService;
        public ParserController()
        {
            ParserService = new ParserService();
        }

        [HttpPost]
        public IActionResult Process([FromBody] UserRequest userRequest)
        {
            var result = ParserService.Process(userRequest.InputText);
            return Ok(result);
        }
    }
}
