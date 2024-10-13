using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using TutorHubAPI.CustomActionFilters;
using TutorHubAPI.Data;
using TutorHubAPI.Models.Domain;
using TutorHubAPI.Models.DTOs;

namespace TutorHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetController : ControllerBase
    {
        private readonly TutorHubAPIDbContext context;

        public PredmetController(TutorHubAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await context.Predmet.ToListAsync();
            if (res != null)
                return Ok(res);
            return BadRequest();
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSubject([FromBody] AddPredmetDTO addPredmetDTO)
        {
            var subject = new Predmet
            {
                Naziv = addPredmetDTO.Naziv
            };
            await context.Predmet.AddAsync(subject);
            await context.SaveChangesAsync();
            return Ok(subject);
        }
    }
}
