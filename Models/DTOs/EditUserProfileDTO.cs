using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.DTOs
{
    public class EditUserProfileDTO
    {
        [Required]
        [MinLength(1)]
        public string Ime { get; set; }
        [Required]
        [MinLength(1)]
        public string Prezime { get; set; }
        [Required]
        [MinLength(1)]
        public string Username { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public string Grad { get; set; }
    }
}
