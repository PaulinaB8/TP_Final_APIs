using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
using TP_Final_APIs.Services.Implementations;
using TP_Final_APIs.Services.Interfaces;
using System.Globalization;

namespace TP_Final_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories([FromQuery]string userName, [FromQuery]string dateBirth)
        {
            // Validar y parsear la fecha
            DateTime fechaNacimiento;
            string[] formatos = {
                "dd/MM/yyyy",  // 15/05/2000
                "dd-MM-yyyy",  // 15-05-2000
                };

            if (!DateTime.TryParseExact(dateBirth, formatos,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out fechaNacimiento))
            {
                return BadRequest("Formato de fecha inválido. Use dd/MM/yyyy, dd-MM-yyyy");
            }

            var response = _categoryService.GetCategories(userName, fechaNacimiento);

            if (response == null)
            {
                return NotFound("No se encontraron categorías.");
            }
            

            return Ok(response);
            
            
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] CreateCategoryDto newCategory)
        {
            var claim = User.FindFirst("sum")
                        ?? User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null) return Unauthorized("El token no tiene id de usuario");

            int userId = int.Parse(claim.Value);

            _categoryService.CreateCategory(userId,newCategory);
            return Ok("Categoría creada correctamente.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory([FromRoute]string categoryName)
        {

            var claim = User.FindFirst("sum")
                        ?? User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null) return Unauthorized("El token no tiene id de usuario");

            int userId = int.Parse(claim.Value);

            try
            {
                _categoryService.DeleteCategory(categoryName, userId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult UpdateCategory([FromBody]UpdateCategoryDto updatedCategory, [FromQuery]string categoryName)
        {

            if (updatedCategory == null)
            {
                return BadRequest("Es necesario cargar datos en la categoría para actualizar.");
            }

            var claim = User.FindFirst("sum")
                        ?? User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null) return Unauthorized("El token no tiene id de usuario");

            int userId = int.Parse(claim.Value);

            var response = _categoryService.UpdateCategory(updatedCategory, categoryName, userId);

            if (response == false)
            {
                return BadRequest();
            }

            return NoContent();
        }




    }
}
