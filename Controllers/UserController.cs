using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
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
    public class UserController : ControllerBase
    {
        private readonly TutorHubAPIDbContext tutorHubAPIDbContext;
        private readonly UserManager<Korisnik> userManager;

        public UserController(TutorHubAPIDbContext tutorHubAPIDbContext, UserManager<Korisnik> userManager)
        {
            this.tutorHubAPIDbContext = tutorHubAPIDbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                if (await userManager.IsInRoleAsync(user, "Professor"))
                {
                    var profesor = await tutorHubAPIDbContext.Profesor
                        .Include(p => p.Korisnik)
                        .Where(p => p.Id_Korisnik == id.ToString())
                        .FirstOrDefaultAsync();

                    var profRes = new GetProfessorResponseDTO
                    {
                        Id = profesor.Id_Korisnik,
                        Ime = profesor.Korisnik.Ime,
                        Prezime = profesor.Korisnik.Prezime,
                        Username = profesor.Korisnik.UserName,
                        Email = profesor.Korisnik.Email,
                        phone = profesor.Korisnik.PhoneNumber,
                        bio = profesor.bio,
                        grad = profesor.Grad,
                        roles = userRoles.ToList()

                    };
                    return Ok(profRes);
                }
                var userRes = new GetUserResponseDTO
                {
                    Id = user.Id,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    Username = user.UserName,
                    Email = user.Email,
                    phone = user.PhoneNumber,
                    roles = userRoles.ToList()
                };
                return Ok(userRes);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> EditProfile([FromRoute] Guid id, [FromBody] EditUserProfileDTO editUserProfileDTO)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound($"User with id '{id}' not found");

            user.Ime = editUserProfileDTO.Ime;
            user.Prezime = editUserProfileDTO.Prezime;
            if(user.UserName != editUserProfileDTO.Username)
            {
                var setUsernameRes = await userManager.SetUserNameAsync(user, editUserProfileDTO.Username);
                if (!setUsernameRes.Succeeded)
                    return BadRequest(setUsernameRes.Errors);
            }
            if(user.PhoneNumber != editUserProfileDTO.Phone)
            {
                var setPhoneRes = await userManager.SetPhoneNumberAsync(user,editUserProfileDTO.Phone);
                if (!setPhoneRes.Succeeded)
                    return BadRequest(setPhoneRes.Errors);
            }

            if (await userManager.IsInRoleAsync(user, "Professor"))
            {
                var professor = await tutorHubAPIDbContext.Profesor.Where(p => p.Id_Korisnik == id.ToString()).FirstOrDefaultAsync();
                professor.bio = editUserProfileDTO.Bio;
                professor.Grad = editUserProfileDTO.Grad;
                await tutorHubAPIDbContext.SaveChangesAsync();
            }

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return NoContent(); // 204 No Content response to indicate success
            }

            return BadRequest(result.Errors);
        }
    }
}
