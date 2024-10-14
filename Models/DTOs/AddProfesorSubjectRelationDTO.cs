using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.DTOs
{
    public class AddProfesorSubjectRelationDTO
    {
        [Required]
        public string Professor_Id { get; set; }
        [Required]
        public int[] predmeti { get; set; }
    }
}
