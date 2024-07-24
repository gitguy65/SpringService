namespace SpringService.Api.Model.Dto
{
    public class LoginResponseDto
    {
        public AppUserDto User { get; set; }
        public string Token {  get; set; }
    }
}
