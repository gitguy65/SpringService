using SpringService.Api.Util;

namespace SpringService.Api.Models.DTO
{
    public record UserProfileDTO( 
            string Slug,
            string FirstName,
            string LastName,
            IFormFile ProfilePicture,
            double Balance,
            string Address, 
            bool IsVerified,
            string? Designation,
            string? Details,
            string? Experience,
            string? Qualification,
            string[] Social,
            ICollection<BookingDTO>? Bookings,
            ICollection<ReviewDTO>? GivenReviews,
            ICollection<ReviewDTO>? ReceivedReviews,
            ICollection<HistoryDTO>? Histories,
            ICollection<PaymentDTO>? Payments
        );
    public record BookingDTO( 
            int UserId,
            UserProfileDTO UserProfileDTO,
            DateTime BookingDate,
            DateTime StartDate,
            int Duration,
            PaymentType PaymentType,
            double Amount,
            double Charge,
            string Description,
            string Message,
            double Longitude,
            double Latitude,
            bool IsAccepted,
            bool IsPaymentConfirmed,
            bool IsJobCompleted,
            bool IsJobCanceled,
            bool IsDeleted
        );
    public record HistoryDTO( 
            int UserId,
            UserProfile UserProfile,
            int ServiceId,
            double Amount,
            string Currency,
            double Charge,
            double Commission,
            string Details,
            string Type
        );
    public record CategoryDTO(
            int Id,
            string Name,
            string Slug,
            string Image,
            string Description,
            bool Status
        );
    public record ReviewDTO(
            int Id,
            string ServiceCategory,
            int ServiceUserId,
            UserProfile ServiceUser,
            int ServiceProviderId,
            UserProfile ServiceProvider,
            DateTime Time,
            string Message,
            double Star
        );
    public record ScheduleDTO( 
            int Id,
            int UserId,
            UserProfile UserProfile,
            string WeekName,
            string StartTime,
            string EndTime,
            bool Status
        );

    public record ServiceDTO(
            int Id,
            string Description,
            UserProfile UserProfile
        );
    public record PaymentDTO(
            int Id,
            int UserId,
            UserProfile UserProfileDTO,
            string ServiceId,
            double Amount,
            string Currency,
            double Charge,
            double Commission,
            string Details,
            PaymentType PaymentType
        );
}
