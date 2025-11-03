using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Services.Interfaces;

namespace ProyectoAgendaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IUserService _userService;

    public AuthenticationController(IConfiguration config, IUserService userService)
    {
        _config = config;
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] CredetialDtoRequest credentials)
    {
        User? user = _userService.Authenticate(credentials.Email, credentials.Password);

        if (user is not null) //arma las 3 partes del jwl token 
        {
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

            var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                //new Claim("role", user.Role)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signature
            );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(tokenToReturn);
        }

        return Unauthorized();
    }
}
