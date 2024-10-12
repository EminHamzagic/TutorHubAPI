using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.Domain
{
    public class Zakazani
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^(Scheduled|Held|Cancelled)$", ErrorMessage = "The value must be either Scheduled,Held or Cancelled.")]
        public string Status { get; set; }
        [Required]
        public DateTime vremeDatum { get; set; }

        //Foreign keys
        [ForeignKey("Oglas")]
        public int Id_Oglasa { get; set; }
        public int Id_Profesora { get; set; } 
        public string Id_Ucenika { get; set; }

        //Navigation properties
        public Oglas Oglas { get; set; }
        public Profesor Profesor { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
