using SpringService.Models; 

namespace SpringService.Services
{
    public class BookingService
    {
        List<Booking> bookings = [];    
        public List<Booking> GetBookings()
        {
            if (bookings.Count > 0)
                return bookings;

            bookings =
            [
                new() {
                    Id = 1,
                    User = new User { FirstName = "John", UserName = "john_doe", LastName = "Doe" },
                    BookingDate = new DateTime(2024, 1, 1, 10, 0, 0),
                    StartDate = new DateTime(2024, 1, 1, 10, 0, 0),
                    EndDate = new DateTime(2024, 1, 1, 11, 0, 0),
                    Amount = 100.0,
                    Charge = 10.0,
                    Message = "Please be on time.",
                    Location = new GeoHashLocation { Address = "123 Main St", City = "New York", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Credit Card",
                    PaymentProof = "proof1.png",
                    IsCompleted = false
                },
                new()
                {
                    Id = 2,
                    User = new User { FirstName = "Jane", UserName = "jane_smith", LastName = "Smith" },
                    BookingDate = new DateTime(2024, 1, 2, 14, 0, 0),
                    StartDate = new DateTime(2024, 1, 2, 14, 0, 0),
                    EndDate = new DateTime(2024, 1, 2, 16, 0, 0),
                    Amount = 200.0,
                    Charge = 20.0,
                    Message = "Bring necessary documents.",
                    Location = new GeoHashLocation { Address = "456 Elm St", City = "San Francisco", Country = "USA" },
                    IsAccepted = false,
                    IsPaymentConfirmed = false,
                    PaymentType = "Paypal",
                    PaymentProof = "proof2.png",
                    IsCompleted = false
                },
                new()
                {
                    Id = 3,
                    User = new User { FirstName = "Alice", UserName = "alice_wonder", LastName = "Wonder" },
                    BookingDate = new DateTime(2024, 1, 3, 9, 0, 0),
                    StartDate = new DateTime(2024, 1, 3, 9, 0, 0),
                    EndDate = new DateTime(2024, 1, 3, 10, 30, 0),
                    Amount = 150.0,
                    Charge = 15.0,
                    Message = "Call on arrival.",
                    Location = new GeoHashLocation { Address = "789 Oak St", City = "Chicago", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Bank Transfer",
                    PaymentProof = "proof3.png",
                    IsCompleted = true
                },
                new()
                {
                    Id = 5,
                    User = new User { FirstName = "Bob", UserName = "bob_builder", LastName = "Builder" },
                    BookingDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    StartDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    EndDate = new DateTime(2024, 1, 4, 12, 30, 0),
                    Amount = 50.0,
                    Charge = 5.0,
                    Message = "Park in visitor area.",
                    Location = new GeoHashLocation { Address = "789 Oak St", City = "Chicago", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Bank Transfer",
                    PaymentProof = "proof3.png",
                    IsCompleted = true
                },
                new()
                {
                    Id = 6,
                    User = new User { FirstName = "Bob", UserName = "bob_builder", LastName = "Builder" }, 
                    BookingDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    StartDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    EndDate = new DateTime(2024, 1, 4, 12, 30, 0),
                    Amount = 50.0,
                    Charge = 5.0,
                    Message = "Park in visitor area.",
                    Location = new GeoHashLocation { Address = "789 Oak St", City = "Chicago", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Bank Transfer",
                    PaymentProof = "proof3.png",
                    IsCompleted = true
                },
                new()
                {
                    Id = 7,
                    User = new User { FirstName = "Bob", UserName = "bob_builder", LastName = "Builder" },
                    BookingDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    StartDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    EndDate = new DateTime(2024, 1, 4, 12, 30, 0),
                    Amount = 50.0,
                    Charge = 5.0,
                    Message = "Park in visitor area.",
                    Location = new GeoHashLocation { Address = "789 Oak St", City = "Chicago", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Bank Transfer",
                    PaymentProof = "proof3.png",
                    IsCompleted = true
                },
                new()
                {
                    Id = 8,
                    User = new User { FirstName = "Bob", UserName = "bob_builder", LastName = "Builder" }, 
                    BookingDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    StartDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    EndDate = new DateTime(2024, 1, 4, 12, 30, 0),
                    Amount = 50.0,
                    Charge = 5.0,
                    Message = "Park in visitor area.",
                    Location = new GeoHashLocation { Address = "789 Oak St", City = "Chicago", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Bank Transfer",
                    PaymentProof = "proof3.png",
                    IsCompleted = true
                },
                new()
                {
                    Id = 9,
                    User = new User { FirstName = "Bob", UserName = "bob_builder", LastName = "Builder" },BookingDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    StartDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    EndDate = new DateTime(2024, 1, 4, 12, 30, 0),
                    Amount = 50.0,
                    Charge = 5.0,
                    Message = "Park in visitor area.",
                    Location = new GeoHashLocation { Address = "789 Oak St", City = "Chicago", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Bank Transfer",
                    PaymentProof = "proof3.png",
                    IsCompleted = true
                },
                new()
                {
                    Id = 10,
                    User = new User { FirstName = "Bob", UserName = "bob_builder", LastName = "Builder" },BookingDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    StartDate = new DateTime(2024, 1, 4, 12, 0, 0),
                    EndDate = new DateTime(2024, 1, 4, 12, 30, 0),
                    Amount = 50.0,
                    Charge = 5.0,
                    Message = "Park in visitor area.",
                    Location = new GeoHashLocation { Address = "789 Oak St", City = "Chicago", Country = "USA" },
                    IsAccepted = true,
                    IsPaymentConfirmed = true,
                    PaymentType = "Bank Transfer",
                    PaymentProof = "proof3.png",
                    IsCompleted = true
                }
            ];
            return bookings;
        }
    }
}
