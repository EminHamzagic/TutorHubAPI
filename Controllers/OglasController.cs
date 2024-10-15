using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorHubAPI.CustomActionFilters;
using TutorHubAPI.Data;
using TutorHubAPI.Models.Domain;
using TutorHubAPI.Models.DTOs;

namespace TutorHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OglasController : ControllerBase
    {
        private readonly TutorHubAPIDbContext context;

        public OglasController(TutorHubAPIDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        [Authorize(Roles = "Professor")]
        [ValidateModel]
        public async Task<IActionResult> AddNewPost([FromBody] AddOglasDTO addOglasDTO)
        {
            if(addOglasDTO.Termini.Length > 0)
            {
                var profesor = await context.Profesor.Where(p => p.Id == addOglasDTO.Id_Profesora).FirstOrDefaultAsync();
                var predmet = await context.Predmet.Where(p => p.Id == addOglasDTO.Id_Predmeta).FirstOrDefaultAsync();
                var oglas = new Oglas
                {
                    Profesor = profesor,
                    Predmet = predmet,
                    Tip = addOglasDTO.Tip,
                    Cena = addOglasDTO.Cena_Casa,
                    datum = addOglasDTO.Datum,
                    Adresa = addOglasDTO.Adresa,
                    Opis = addOglasDTO.Opis
                };
                //var terminList = new List<Termini>();
                foreach(var t in addOglasDTO.Termini)
                {
                    var terminStr = t.Split(",");
                    var termin = new Termini
                    {
                        vreme_Od_Do = terminStr[0],
                        Br_ucenika = Int32.Parse(terminStr[1])
                    };
                    oglas.Terminis.Add(termin);
                    //terminList.Add(termin);
                }
                await context.Oglas.AddAsync(oglas);
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
