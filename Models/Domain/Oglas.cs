using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.Domain
{
    public class Oglas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^(Group|Individual)$", ErrorMessage = "The value must be either Group or Individual.")]
        public string Tip { get; set; }
        [Required]
        public int Cena { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Opis { get; set; }

        //Foreign keys
        public int Id_Profesora { get; set; }
        public int Id_Predmeta { get; set; }

        //Navigation properties
        public Profesor Profesor { get; set; }
        public Predmet Predmet { get; set; }
        public ICollection<Termini> Terminis { get; set; }
        public Zakazani Zakazani { get; set; }
    }
}
