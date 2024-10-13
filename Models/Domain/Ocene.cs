using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.Domain
{
    public class Ocene
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public double Ocena { get; set; }
        [Required]
        [StringLength(250)]
        public string Komentar { get; set; }

        //Foreign keys
        [ForeignKey("Profesor")]
        public int Id_Profesora { get; set; }
        [ForeignKey("Korisnik")]
        public string Id_Komentatora { get; set; }

        //Navigation properties
        public Profesor Profesor { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
