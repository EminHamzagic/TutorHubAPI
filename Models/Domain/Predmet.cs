using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.Domain
{
    public class Predmet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Naziv { get; set; }

        //Navigation properties
        public ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();
        public ICollection<Oglas> Oglas { get; set; } = new List<Oglas>();
    }
}
