using TutorHubAPI.Models.Domain;

namespace TutorHubAPI.Models.DTOs
{
    public class LoginResponseDTO
    {
        public string token { get; set; }
        public string korisnik_Id { get; set; }
    }
}
