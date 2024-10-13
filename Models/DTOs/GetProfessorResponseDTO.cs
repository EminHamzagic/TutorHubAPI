namespace TutorHubAPI.Models.DTOs
{
    public class GetProfessorResponseDTO
    {
        public string Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? phone { get; set; }
        public string bio { get; set; }
        public string grad { get; set; }
        public double Ocena { get; set; }
        public List<string> roles { get; set; }
    }
}
