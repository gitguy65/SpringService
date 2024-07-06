using SpringService.Api.Models;

namespace SpringService.Api.Model.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }
        /*public User User { get; set; }*/
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Amount { get; set; }
        public double Charge { get; set; }
        public string Message { get; set; }
        public GeoHashLocation Location { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public string PaymentType { get; set; }
        public string PaymentProof { get; set; }
        public bool IsCompleted { get; set; }
    }
}
