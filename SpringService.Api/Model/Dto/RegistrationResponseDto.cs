namespace SpringService.Api.Model.Dto
{
    public class RegistrationResponseDto
    {
        public AppUserDto User { get; set; }
        public string Token { get; set; }
    }
}
