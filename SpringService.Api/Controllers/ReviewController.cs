using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Models;

namespace SpringService.Api.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : Controller
    {
        [HttpGet("/popular")]
        public IActionResult Get() {
            return Ok("succesfully created");
        }

        [HttpGet("/{userid}")]
        public IActionResult Get(int userid)
        {
            return Ok("succesfully created");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id) 
        {
            return Ok("succesfully created");
        }
    }
}
