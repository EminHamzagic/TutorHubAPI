using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using TutorHubAPI.CustomActionFilters;
using TutorHubAPI.Data;
using TutorHubAPI.Models.Domain;
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
            var profesors = await context.Profesor
                .Include(p => p.Predmets)
                .Include(p => p.Korisnik)
                .Include(p => p.Ocenes)
                .ToListAsync();
            var profRes = new List<GetProfessorResponseDTO>();
            foreach (var prof in profesors)
            {
                var predmeti = new List<GetPredmetResDTO>();
                foreach (var subj in prof.Predmets)
                    predmeti.Add(new GetPredmetResDTO
                    {
                        Id = subj.Id,
                        naziv = subj.Naziv
                    });

                var rating = prof.Ocenes.Select(o => o.Ocena).ToList();
                rating.Add(prof.Ocena);
                GetProfessorResponseDTO profDto = new GetProfessorResponseDTO
                {
                    Id = prof.Id_Korisnik,
                    Ime = prof.Korisnik.Ime,
                    Prezime = prof.Korisnik.Prezime,
                    Username = prof.Korisnik.UserName,
                    Email = prof.Korisnik.Email,
                    phone = prof.Korisnik.PhoneNumber,
                    bio = prof.bio,
                    grad = prof.Grad,
                    Ocena = rating.Sum() / rating.Count(),
                    pfpUrl = prof.pfpUrl,
                    predmeti = predmeti
                };
                profRes.Add(profDto);
            }
            var profesorsQueryable = profRes.AsQueryable();
            profesorsQueryable = IsAscending ? profesorsQueryable.OrderBy(x => x.Ocena) : profesorsQueryable.OrderByDescending(x => x.Ocena);
            return Ok(profesorsQueryable.ToList());
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

        [HttpPost("setPfp")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> UploadProfilePicture([FromForm] AddPfpDTO addPfpDTO)
        {
            var professor = await context.Profesor.Where(p => p.Id_Korisnik == addPfpDTO.professor_Id).FirstOrDefaultAsync();
            if (professor == null)
                return BadRequest();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", "44a7273a9740e87");

                using (var content = new MultipartFormDataContent())
                {
                    var fileStream = addPfpDTO.image.OpenReadStream();
                    var streamContent = new StreamContent(fileStream);
                    content.Add(streamContent, "image", addPfpDTO.image.FileName);

                    var response = await httpClient.PostAsync("https://api.imgur.com/3/image", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest();
                    }

                    var responseData = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData);
                    var imageUrl = jsonResponse.data.link;

                    professor.pfpUrl = imageUrl;
                    await context.SaveChangesAsync();
                    return Ok(imageUrl);
                }
            }
        }

    }
}
