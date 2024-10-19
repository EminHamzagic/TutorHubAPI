using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.DTOs
{
    public class EditReviewDTO
    {
        [Required]
        public int Id_Komentara { get; set; }
        [Required]
        public string Komentar { get; set; }
        [Required]
        public double Ocena { get; set; }
    }
}
