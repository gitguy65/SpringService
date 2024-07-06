using SpringService.Models;

namespace SpringService.Services.IService
{
    interface IReviewService
    {
        List<Review> GetPopularReviews();
    }
}
