using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TutorHubAPI.CustomActionFilters;
using TutorHubAPI.Data;
using TutorHubAPI.Functions;
using TutorHubAPI.Helpers;
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
                    Naslov = addOglasDTO.Naslov,
                    Tip = addOglasDTO.Tip,
                    Cena = addOglasDTO.Cena_Casa,
                    datum = addOglasDTO.Datum,
                    Adresa = addOglasDTO.Adresa,
                    Opis = addOglasDTO.Opis,
                    Namenjeno_Obrazovanje = addOglasDTO.Namenjeno_Obrazovanje
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
        public async Task<IActionResult> GetAllPosts([FromQuery] OglasQueryParameters? parameters, [FromQuery] bool isAscending = true)
        {
            // Start building the query, applying filters and including necessary relations.
            var query = context.Oglas
                .Include(o => o.Terminis)
                .Include(o => o.Profesor)
                .Include(o => o.Predmet)
                .AsQueryable();

            // Apply filters
            if (parameters != null && !string.IsNullOrEmpty(parameters.FilterType) && !string.IsNullOrEmpty(parameters.FilterProperty))
            {
                switch (parameters.FilterType)
                {
                    case "Predmet":
                        query = query.Where(o => o.Predmet.Naziv == parameters.FilterProperty);
                        break;
                }
            }

            query = query.Where(o => o.Naslov.Contains(parameters.SearchText) || o.Profesor.Grad.Contains(parameters.SearchGrad));

            // Apply sorting
            if (!string.IsNullOrEmpty(parameters.SortProperty))
            {
                switch (parameters.SortProperty)
                {
                    case "Ocena":
                        query = isAscending ? query.OrderBy(p => p.Profesor.Ocena) : query.OrderByDescending(p => p.Profesor.Ocena);
                        break;
                    case "Obrazovanje":
                        query = isAscending ? query.OrderBy(p => p.Namenjeno_Obrazovanje) : query.OrderByDescending(p => p.Namenjeno_Obrazovanje);
                        break;
                    case "Cena":
                        query = isAscending ? query.OrderBy(p => p.Cena) : query.OrderByDescending(p => p.Cena);
                        break;
                }
            }
                query = isAscending ? query.OrderBy(p => p.datum) : query.OrderByDescending(p => p.datum);

            // Project to the DTO directly to avoid fetching unnecessary fields.
            var postRes = await query
                .Where(o => o.datum >= DateTime.Now)  // Only posts with future dates
                .Select(post => new GetOglasResponseDTO
                {
                    Oglas_Id = post.Id,
                    Id_Profesora = post.Id_Profesora,
                    Id_Predmeta = post.Id_Predmeta,
                    Naslov = post.Naslov,
                    Tip = post.Tip,
                    Cena_Casa = post.Cena,
                    Datum = post.datum,
                    Adresa = post.Adresa,
                    Opis = post.Opis,
                    Namenjeno_Obrazovanje = post.Namenjeno_Obrazovanje,
                    Grad = post.Profesor.Grad,
                    Termini = post.Terminis
                        .Where(t => t.Br_ucenika > 0)  // Only include termini with available spots
                        .Select(termin => new GetTerminResDTO
                        {
                            Id = termin.Id,
                            vreme_Od_Do = termin.vreme_Od_Do,
                            Br_ucenika = termin.Br_ucenika
                        }).ToList()  // Fetch termini with positive 'Br_ucenika'
                })
                .Where(post => post.Termini.Count > 0)  // Ensure posts have valid termini
                .ToListAsync();

            return Ok(postRes);
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
