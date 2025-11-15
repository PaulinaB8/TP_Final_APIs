using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
using TP_Final_APIs.Services.Interfaces;

namespace TP_Final_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController (IUserService userService)
        {
            _userService = userService;
        }

      

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAllRestaurants());
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateRestaurant([FromBody]CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Es necesario cargar los datos del usuario.");
            }
            var userCreated = _userService.CreateRestaurant(userDto);
            return Ok(userCreated);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody]UpdateUserDto userDto)
        {
            var claim = User.FindFirst("sum")
                        ?? User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null) return Unauthorized("El token no tiene id de usuario");

            int userId = int.Parse(claim.Value);

            var response = _userService.UpdateUser(userDto, userId);
            if (userDto is null)
            {
                return BadRequest("Es necesario cargar los datos del usuario para actualizar");
            }

            if (response is null)
            {
                return NotFound($"Usuario con ID {userId} no encontrado");
            }

            return Ok("Actualización exitosa");
        }

        [HttpDelete]
        public IActionResult DeleteUser()
        {

            var claim = User.FindFirst("sum")
                        ?? User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null) return Unauthorized("El token no tiene id de usuario");

            int userId = int.Parse(claim.Value);

            var response = _userService.DeleteUser(userId);

            if (response == null)
            {
                return NotFound($"El ID {userId} no fue encontrado");
            }
            else return NoContent();

            
        }

        

    }
}
