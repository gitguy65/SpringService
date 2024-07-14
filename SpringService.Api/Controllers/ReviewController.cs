using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Models;

namespace SpringService.Api.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : Controller
    {
        [HttpGet("top-reviews")]
        public IActionResult FetchPopular() {
            throw new NotImplementedException();
        }

        [HttpGet("given-reviews")]
        public IActionResult GivenReviews(User user)
        {
            throw new NotImplementedException();
        }

        [HttpGet("recieved-reviews")]
        public IActionResult ReceivedReviews(User user)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult GiveReview(Review review) { 
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateReview(Review review) { 
            throw new NotImplementedException(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            throw new NotImplementedException();
        }
    }
}
