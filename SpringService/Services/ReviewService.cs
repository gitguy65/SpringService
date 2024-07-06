using SpringService.Models;
using SpringService.Services.IService;

namespace SpringService.Services
{
    public class ReviewService : IReviewService
    {
        List<Review> popularReviews = [];  

        public List<Review> GetPopularReviews()
        {
            if (popularReviews.Count > 0)
                return popularReviews;

            popularReviews = [
                new(){
                    Id = 1, 
                    ServiceCategory = "Tech Repair",
                    Message = "Best in class",
                    Star = 4
                },
                new(){
                    Id = 2,
                    ServiceCategory = "Delivery",
                    Message = "Best in class",
                    Star = 4
                },
                new(){
                    Id = 3,
                    ServiceCategory = "Tech Repair",
                    Message = "Best in class",
                    Star = 4
                },
                new(){
                    Id = 4,
                    ServiceCategory = "Tech Repair",
                    Message = "Best in class",
                    Star = 4
                }
            ];

            return popularReviews;
        }
    }
}