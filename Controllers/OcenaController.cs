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
    public class OcenaController : ControllerBase
    {
        private readonly TutorHubAPIDbContext context;

        public OcenaController(TutorHubAPIDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> AddReview([FromBody] AddOcenaDTO addOcenaDTO)
        {
            var profesor = await context.Profesor.Where(p => p.Id == addOcenaDTO.Id_Profesora).FirstOrDefaultAsync();
            if (profesor == null)
                return BadRequest();
            var ocena = new Ocene
            {
                Id_Komentatora = addOcenaDTO.Id_Ucenika,
                Id_Profesora = addOcenaDTO.Id_Profesora,
                Ocena = addOcenaDTO.Ocena,
                Komentar = addOcenaDTO.Komentar
            };

            await context.Ocene.AddAsync(ocena);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> ChangeReview([FromBody] EditReviewDTO editReviewDTO)
        {
            var komentar = await context.Ocene.Where(o => o.Id == editReviewDTO.Id_Komentara).FirstOrDefaultAsync();
            if (komentar == null)
                return BadRequest();

            double staraOcena = komentar.Ocena;
            komentar.Komentar = editReviewDTO.Komentar;
            komentar.Ocena = editReviewDTO.Ocena;

            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
