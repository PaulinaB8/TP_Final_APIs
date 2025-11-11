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
        //[AllowAnonymous]
        public IActionResult CreateRestaurant([FromBody]CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid User data.");
            }
            var userCreated = _userService.CreateRestaurant(userDto);
            return Ok(userCreated);
        }

        [HttpPut("{idUser}")]
        public IActionResult UpdateUser([FromBody]UpdateUserDto userDto, [FromRoute]int idUser)
        {
            if (userDto is null)
            {
                return BadRequest("User data is required for update");
            }

            if (_userService.CheckIfUserExists(idUser) == false)
            {
                return NotFound($"User with ID {idUser} not found");
            }

            _userService.UpdateUser(userDto, idUser);
            return NoContent();
        }

        [HttpDelete("{idUser}")]
        public IActionResult DeleteUser([FromRoute]int idUser)
        {
            if (_userService.CheckIfUserExists(idUser) == false)
            {
                return NotFound($"The ID {idUser} wasn´t found");
            }

            _userService.DeleteUser(idUser);
            return NoContent();
        }

        //IEnumerable<UserDto> GetAllRestaurants();
        //UserDto CreateRestaurant(CreateAndUpdateUserDto newRestaurantDto);
        //void DeleteUser(int idUser);
        //void UpdateUser(CreateAndUpdateUserDto updatedUserDto, int idUser);

    }
}
