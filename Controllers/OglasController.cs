using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TutorHubAPI.CustomActionFilters;
using TutorHubAPI.Data;
using TutorHubAPI.Functions;
using TutorHubAPI.Models.Domain;
using TutorHubAPI.Models.DTOs;

namespace TutorHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OglasController : ControllerBase
    {
        private readonly TutorHubAPIDbContext context;
        public Overlapping check = new Overlapping();

        public OglasController(TutorHubAPIDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        [Authorize(Roles = "Professor, Admin")]
        [ValidateModel]
        public async Task<IActionResult> AddNewPost([FromBody] AddOglasDTO addOglasDTO)
        {
            if(addOglasDTO.Termini.Length > 0)
            {
                    

                var profesor = await context.Profesor.Where(p => p.Id == addOglasDTO.Id_Profesora).FirstOrDefaultAsync();
                var predmet = await context.Predmet.Where(p => p.Id == addOglasDTO.Id_Predmeta).FirstOrDefaultAsync();
                var oglas = new Oglas
                {
                    Id_Profesora = profesor.Id,
                    Id_Predmeta = predmet.Id,
                    Tip = addOglasDTO.Tip,
                    Cena = addOglasDTO.Cena_Casa,
                    datum = addOglasDTO.Datum,
                    Adresa = addOglasDTO.Adresa,
                    Opis = addOglasDTO.Opis
                };

                foreach(var t in addOglasDTO.Termini)
                {
                    var terminStr = t.Split(",");
                    var termin = new Termini
                    {
                        vreme_Od_Do = terminStr[0],
                        Br_ucenika = Int32.Parse(terminStr[1])
                    };
                    oglas.Terminis.Add(termin);
                    
                }

                var provera = context.Oglas
                    .Where(o => o.datum.Date == addOglasDTO.Datum.Date && o.Id_Profesora == oglas.Id_Profesora)
                    .Include(o => o.Terminis)
                    .Select(o => o.Terminis);
                if (provera != null)
                {

                    foreach(var post in provera)
                    {
                        var list = oglas.Terminis.Select(tr => tr.vreme_Od_Do).Concat(post.Select(t => t.vreme_Od_Do)).ToList();
                        if (check.CheckForNonOverlappingIntervals(list));
                            return BadRequest("Vec imate oglas sa nekim od izabranih termina izabranog datuma");
                    }
                }

                await context.Oglas.AddAsync(oglas);
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GettAllPosts([FromQuery] string? subject, [FromQuery] bool isAscending = true)
        {
            var posts = await context.Oglas.Include(o => o.Terminis).ToListAsync();
            var postRes = new List<GetOglasResponseDTO>();
            foreach(var post in posts)
            {
                if (post.datum < DateTime.Now)
                    continue;
                var terminiRes = new List<GetTerminResDTO>();
                foreach(var termin in post.Terminis)
                {
                    if (termin.Br_ucenika <= 0)
                        continue;
                    var t = new GetTerminResDTO
                    {
                        Id = termin.Id,
                        vreme_Od_Do = termin.vreme_Od_Do,
                        Br_ucenika = termin.Br_ucenika
                    };
                    terminiRes.Add(t);
                }
                if (terminiRes.Count() <= 0)
                    continue;
                var res = new GetOglasResponseDTO
                {
                    Oglas_Id = post.Id,
                    Id_Profesora = post.Id_Profesora,
                    Id_Predmeta = post.Id_Predmeta,
                    Tip = post.Tip,
                    Cena_Casa = post.Cena,
                    Datum= post.datum,
                    Adresa = post.Adresa,
                    Opis = post.Opis,
                    Termini = terminiRes
                };
                postRes.Add(res);
            }
            if (posts != null)
            {
                var qPostRes = postRes.AsQueryable();
                if (!string.IsNullOrEmpty(subject))
                {
                    var predmet = await context.Predmet.Where(p => p.Naziv == subject).FirstOrDefaultAsync();
                    if(predmet != null)
                    {
                        qPostRes = qPostRes.Where(x => x.Id_Predmeta == predmet.Id);
                    }
                }
                qPostRes = isAscending ? qPostRes.OrderBy(p => p.Datum) : qPostRes.OrderByDescending(p => p.Datum);
                return Ok(qPostRes.ToList());
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var post = await context.Oglas.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (post == null)
                return BadRequest();

            context.Oglas.Remove(post);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
