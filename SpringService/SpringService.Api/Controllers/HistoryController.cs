using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Models;

namespace SpringService.Api.Controllers
{
    [Route("api/v1/history")]
    [ApiController]
    public class HistoryController : Controller
    {
        [HttpGet("fetch-all-history")]
        public IActionResult FetchAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("fetch-user-history/{Id:int}")]
        public IActionResult FetchAll(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("add-user-history")]
        public IActionResult CreateHistory(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
