namespace Manga360.Api.Domain.Entities.User
{
    public class UserToken
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}