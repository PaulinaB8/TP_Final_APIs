using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("{idUser}")]
        public IActionResult UpdateUser([FromBody]UpdateUserDto userDto, [FromRoute]int idUser)
        {
            var response = _userService.UpdateUser(userDto, idUser);
            if (userDto is null)
            {
                return BadRequest("Es necesario cargar los datos del usuario para actualizar");
            }

            if (response is null)
            {
                return NotFound($"Usuario con ID {idUser} no encontrado");
            }

            return Ok("Actualización exitosa");
        }

        [HttpDelete("{idUser}")]
        public IActionResult DeleteUser([FromRoute]int idUser)
        {
            var response = _userService.DeleteUser(idUser);

            if (response == null)
            {
                return NotFound($"El ID {idUser} no fue encontrado");
            }
            else return NoContent();

            
        }

        

    }
}
