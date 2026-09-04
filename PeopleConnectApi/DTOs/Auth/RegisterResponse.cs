namespace PeopleConnectApi.DTOs.Auth
{
    public class RegisterResponse
    {
        public string Message { get; set; } = string.Empty;
        public string UserId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
