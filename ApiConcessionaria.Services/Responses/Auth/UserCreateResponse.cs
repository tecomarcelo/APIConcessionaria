namespace ApiConcessionaria.Services.Responses.Auth
{
    public class UserCreateResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
