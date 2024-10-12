using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.Domain
{
    public class Termini
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string vreme_Od_Do { get; set; }
        [Required]
        public int Br_ucenika { get; set; }

        //Foreign keys
        public int Id_Oglasa { get; set; }

        //Navigation properties
        public Oglas Oglas { get; set; }
    }
}
