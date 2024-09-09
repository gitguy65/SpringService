using System.ComponentModel.DataAnnotations;

namespace SpringService.Api.Model.Dto
{
    public class RegistrationRequestDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string? Designation { get; set; }
        public string? Details { get; set; }
        public string? Experience { get; set; }
        public string? Qualification { get; set; }
        public bool IsVerified { get; set; }
        public string Social { get; set; }
    }
}
