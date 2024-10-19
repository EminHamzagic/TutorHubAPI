using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.Domain
{
    public class Profesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string bio { get; set; }
        [Required]
        [StringLength(50)]
        public string Grad { get; set; }
        public double Ocena { get; set; }
        public string pfpUrl { get; set; }

        //Foreign keys
        [ForeignKey("Korisnik")]
        public string Id_Korisnik { get; set; }

        //Navigation properties
        public Korisnik Korisnik { get; set; }
        public ICollection<Predmet> Predmets { get; set; } = new List<Predmet>();
        public ICollection<Oglas> Oglas { get; set; } = new List<Oglas>();
        public ICollection<Zakazani> Zakazanis { get; set; } = new List<Zakazani>();
        public ICollection<Ocene> Ocenes { get; set; } = new List<Ocene>();
    }
}
