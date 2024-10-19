using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.DTOs
{
    public class GetTerminResDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string vreme_Od_Do { get; set; }
        [Required]
        public int Br_ucenika { get; set; }
    }
}
