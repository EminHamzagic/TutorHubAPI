using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TutorHubAPI.CustomActionFilters;
using TutorHubAPI.Data;
using TutorHubAPI.Models.DTOs;

namespace TutorHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly TutorHubAPIDbContext context;

        public ProfesorController(TutorHubAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool IsAscending = true)
        {
            var profesors = context.Profesor.AsQueryable();
            profesors = IsAscending ? profesors.OrderBy(x => x.Ocena) : profesors.OrderByDescending(x => x.Ocena);
            return Ok(await profesors.ToListAsync());
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> AddSubjectRelation([FromBody] AddProfesorSubjectRelationDTO dto)
        {
            var predmeti = await context.Predmet.Where(s => dto.predmeti.Contains(s.Id)).ToListAsync();
            var prof = await context.Profesor.Where(p => p.Id_Korisnik == dto.Professor_Id).FirstOrDefaultAsync();
            if(prof != null && predmeti != null)
            {
                foreach (var subj in predmeti)
                    prof.Predmets.Add(subj);
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
