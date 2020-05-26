namespace PublicApi.DTO.V1.Account
{
    public class LoginResponse
    {
        public string Status { get; set; } = default!;
        public string Token { get; set; } = default!;
        public bool HasActiveRoutine { get; set; } = default!;
    }
}