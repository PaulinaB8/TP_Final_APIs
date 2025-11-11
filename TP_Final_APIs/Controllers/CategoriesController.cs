using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
using TP_Final_APIs.Services.Implementations;
using TP_Final_APIs.Services.Interfaces;

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

        [HttpGet("{idUser}/{dateBirth}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories([FromRoute]int idUser, [FromQuery]DateTime dateBirth)
        {
            var responseComplete = _categoryService.GetCategories(idUser);

            if (responseComplete == null)
            {
                return NotFound("No se encontraron categorías.");
            }

            int edad = DateTime.Today.Year - dateBirth.Year;

            if (dateBirth.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad > 18)
            {
                return Ok(responseComplete);
            }else
            {
                return Ok();
            }
            
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] CreateAndUpdateCategoryDto newCategory)
        {
        
            _categoryService.CreateCategory(newCategory);
            return Ok("Categoría creada correctamente.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute]int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
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

        [HttpPut("{idCategory}")]
        public IActionResult UpdateCategory([FromBody]CreateAndUpdateCategoryDto updatedCategory, [FromRoute]int idCategory)
        {
            if (updatedCategory == null)
            {
                return BadRequest("Category data is required for update.");
            }
            if (_categoryService.CheckIfCategoryExists(idCategory) == false)
            {
                return NotFound($"User with ID {idCategory} not found");
            }

            _categoryService.UpdateCategory(updatedCategory, idCategory);

            return NoContent();
        }


    }
}
