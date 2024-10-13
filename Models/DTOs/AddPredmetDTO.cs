using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.DTOs
{
    public class AddPredmetDTO
    {
        [Required]
        [MinLength(3)]
        public string Naziv { get; set; }
    }
}
