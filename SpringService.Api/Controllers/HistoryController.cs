using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Models;

namespace SpringService.Api.Controllers
{
    [Route("api/history/")]
    [ApiController]
    public class HistoryController : Controller
    {
        [HttpGet("fetch-all")]
        public IActionResult FetchAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("fetch/{id:int}")]
        public IActionResult FetchAll(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
