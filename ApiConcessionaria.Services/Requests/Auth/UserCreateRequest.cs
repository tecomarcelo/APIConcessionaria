namespace ApiConcessionaria.Services.Requests.Auth
{
    public class UserCreateRequest
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
    }
}
