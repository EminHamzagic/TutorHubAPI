using Azure.Core;
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
    public class ZakazaniController : ControllerBase
    {
        private readonly TutorHubAPIDbContext context;

        public ZakazaniController(TutorHubAPIDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Authorize]
        [ValidateModel]
        public async Task<IActionResult> Appoint([FromBody] AddZakazaniDTO addZakazaniDTO)
        {
            var oglas = await context.Oglas.Where(o => o.Id == addZakazaniDTO.Id_Oglasa).FirstOrDefaultAsync();
            
            if (oglas == null)
                return BadRequest();

            var cas = new Zakazani
            {
                Id_Oglasa = addZakazaniDTO.Id_Oglasa,
                Id_Profesora = addZakazaniDTO.Id_Profesora,
                Id_Ucenika = addZakazaniDTO.Id_Ucenika,
                Status = addZakazaniDTO.status,
                vremeDatum = addZakazaniDTO.datum,
                vremeOd_Do = addZakazaniDTO.vremeOd_Do
            };
            var termin = await context.Termini
                .Where(t => t.Id_Oglasa == addZakazaniDTO.Id_Oglasa && t.vreme_Od_Do == addZakazaniDTO.vremeOd_Do)
                .FirstOrDefaultAsync();

            termin.Br_ucenika -= 1;
            await context.Zakazani.AddAsync(cas);
            await context.SaveChangesAsync();
            return Ok(cas);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> CallOff([FromRoute] int id)
        {
            var cas = await context.Zakazani.Where(z => z.Id == id).FirstOrDefaultAsync();
            if (cas == null)
                return BadRequest();

            cas.Status = "Otkazano";
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
