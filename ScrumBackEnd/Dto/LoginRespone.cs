namespace ScrumBackEnd.Dto
{
    public class LoginRespone
    {
        public bool Success { get; set; } = false;
        public string Data { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;   
    }
}
