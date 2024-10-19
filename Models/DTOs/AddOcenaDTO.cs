using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TutorHubAPI.Models.DTOs
{
    public class AddOcenaDTO
    {
        [Required]
        public int Id_Profesora { get; set; }
        [Required]
        public string Id_Ucenika { get; set; }
        [Required]
        public string Komentar{ get; set; }
        [Required]
        public double Ocena { get; set; }
    }
}
