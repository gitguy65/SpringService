using Microsoft.AspNetCore.Mvc;
using SpringService.Api.Models;

namespace SpringService.Api.Controllers
{
    [Route("api/v1/review")]
    [ApiController]
    public class ReviewController : Controller
    {
        [HttpGet("top-reviews")]
        public IActionResult FetchPopular() {
            throw new NotImplementedException();
        }

        [HttpGet("user-given-reviews")]
        public IActionResult GivenReviews(User user)
        {
            throw new NotImplementedException();
        }

        [HttpGet("user-recieved-reviews")]
        public IActionResult ReceivedReviews(User user)
        {
            throw new NotImplementedException();
        }

        [HttpPost("add-review")]
        public IActionResult GiveReview(Review review) { 
            throw new NotImplementedException();
        }

        [HttpPut("update-review")]
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
