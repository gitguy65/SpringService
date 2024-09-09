using SpringApi.Util;

namespace SpringApi.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; } ="";
        public UserProfile UserProfile { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public PaymentType PaymentType { get; set; }
        public double Amount { get; set; }
        public double Charge { get; set; }
        public string Description { get; set; } ="";
        public string Message { get; set; } ="";
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public bool IsJobCompleted { get; set; }
        public bool IsJobCanceled { get; set; }
        public bool IsDeleted { get; set; }
    }
}