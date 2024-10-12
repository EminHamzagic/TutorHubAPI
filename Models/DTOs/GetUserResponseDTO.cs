namespace TutorHubAPI.Models.DTOs
{
    public class GetUserResponseDTO
    {
        public string Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? phone { get; set; }
        public List<string> roles { get; set; }
    }
}
