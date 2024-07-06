using Microsoft.AspNetCore.Mvc;

namespace SpringService.Api.Controllers
{
    [Route("api/history")]
    [ApiController]
    public class HistoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
