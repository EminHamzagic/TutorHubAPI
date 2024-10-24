using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TutorHubAPI.CustomActionFilters;
using TutorHubAPI.Data;
using TutorHubAPI.Models.Domain;
using TutorHubAPI.Models.DTOs;

namespace TutorHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Korisnik> userManager;
        private readonly IConfiguration configuration;
        private readonly TutorHubAPIDbContext context;

        public AuthController(UserManager<Korisnik> userManager, IConfiguration configuration, TutorHubAPIDbContext context)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.context = context;
        }

        [HttpPost]
        [Route("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var User = new Korisnik
            {
                UserName = registerRequestDTO.email,
                Email = registerRequestDTO.email,
                Ime = registerRequestDTO.ime,
                Prezime = registerRequestDTO.prezime,
                PhoneNumber = registerRequestDTO.phone

            };
            var identityResult = await userManager.CreateAsync(User, registerRequestDTO.password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDTO.roles != null && registerRequestDTO.roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(User, registerRequestDTO.roles);
                    if (identityResult.Succeeded)
                        if (registerRequestDTO.roles.Contains("Professor"))
                        {
                            var professor = new Profesor
                            {
                                Id_Korisnik = User.Id,
                                bio = registerRequestDTO.bio,
                                Grad = registerRequestDTO.grad,
                                Ocena = 10
                            };
                            await context.Profesor.AddAsync(professor);
                            await context.SaveChangesAsync();
                        }
                        return Ok(User.Id.ToString());
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.email);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.password);
                if (checkPasswordResult)
                {
                    var tempRoles = await userManager.GetRolesAsync(user);
                    if (tempRoles != null)
                    {
                        var roles = tempRoles.ToList();
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Email, loginRequestDTO.email));

                        foreach (var role in roles)
                            claims.Add(new Claim(ClaimTypes.Role, role));

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            configuration["Jwt:Issuer"],
                            configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(120),
                            signingCredentials: credentials);

                        var JwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                        var response = new LoginResponseDTO
                        {
                            token = JwtToken,
                            korisnik_Id = user.Id
                        };

                        return Ok(response);

                    }


                }
            }
            return BadRequest();
        }
    }
}
