namespace TutorHubAPI.Models.DTOs
{
    public class AddPfpDTO
    {
        public IFormFile image { get; set; }
        public string professor_Id { get; set; }
    }
}
