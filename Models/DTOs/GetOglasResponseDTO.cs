using System.ComponentModel.DataAnnotations;
using TutorHubAPI.Models.Domain;

namespace TutorHubAPI.Models.DTOs
{
    public class GetOglasResponseDTO
    {
        [Required]
        public int Oglas_Id { get; set; }
        [Required]
        public int Id_Profesora { get; set; }
        [Required]
        public int Id_Predmeta { get; set; }
        public string Naslov { get; set; }
        [Required]
        public string Tip { get; set; }
        public string Grad { get; set; }
        public string Namenjeno_Obrazovanje { get; set; }
        [Required]
        public int Cena_Casa { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Opis { get; set; }
        public List<GetTerminResDTO> Termini { get; set; }
    }
}
