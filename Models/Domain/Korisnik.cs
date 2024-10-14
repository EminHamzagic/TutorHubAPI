using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorHubAPI.Models.Domain
{
    public class Korisnik: IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        //Navigation properties
        public ICollection<Zakazani> Zakazanis { get; set; } = new List<Zakazani>();
        public ICollection<Ocene> Ocenes { get; set; } = new List<Ocene>();

    }
}
