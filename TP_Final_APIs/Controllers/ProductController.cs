using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
using TP_Final_APIs.Services.Interfaces;

namespace TP_Final_APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class ProductController : ControllerBase
{
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    private readonly IProductService _productService;





    [HttpGet("category")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetProductsByCategory([FromQuery] string userName, [FromQuery] string categoryName, [FromQuery] string dateBirth)
    {
        if(string.IsNullOrWhiteSpace(categoryName) | string.IsNullOrWhiteSpace(userName))
        {
            return BadRequest("Ingrese el nombre de la categoría");
        }
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

        var ageValidation = _productService.AgeValidation(fechaNacimiento, categoryName);

        if(ageValidation is false)
        {
            return BadRequest("Siendo menor de edad no puede ingresar a la categoría 'Bebidas Alcohólicas'");
        }

        var response = _productService.GetProductsByCategory(categoryName, userName);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }



    [HttpGet]
    [AllowAnonymous]
    public ActionResult<ProductDto> GetProduct([FromQuery] string productName)
    {
        var response = _productService.GetProduct(productName);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet("favourites")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<FavouriteProductsDto>> GetFavouriteProducts([FromQuery] string userName)
    {
        var response = _productService.GetFavouriteProducts(userName);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet("discountProducts")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductsWithDiscountDto>> GetDiscountProducts([FromQuery] string userName)
    {
        var response = _productService.GetDiscountProducts(userName);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet("happyhour")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<FavouriteProductsDto>> GetHappyHourProducts([FromQuery] string userName)
    {
        var response = _productService.GetHappyHourProducts(userName);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpPost]
    public ActionResult CreateProduct([FromBody]CreateProductDto newProduct, [FromQuery] string categoryName)
    {
        var claim = User.FindFirst("sum")
                        ?? User.FindFirst(ClaimTypes.NameIdentifier);

        if (claim == null) return Unauthorized("El token no tiene id de usuario");

        int userId = int.Parse(claim.Value);

        _productService.CreateProduct(newProduct, categoryName, userId);
        return Ok("Producto creado");

    }

    [HttpDelete]
    public ActionResult DeleteProduct([FromQuery] string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
            return BadRequest("Debe especificar el nombre del producto.");


        var claim = User.FindFirst("sum")
                        ?? User.FindFirst(ClaimTypes.NameIdentifier);

        if (claim == null) return Unauthorized("El token no tiene id de usuario");

        int userId = int.Parse(claim.Value);

        
        _productService.DeleteProduct(productName, userId);
        return Ok("Producto eliminado");
    }


    [HttpPut]
    public ActionResult UpdateProduct([FromBody]UpdateProductDto updatedProduct, [FromQuery]string productName)
    {
        _productService.UpdateProduct(updatedProduct, productName);
        return Ok("Producto editado");
    }

    [HttpPatch("discount")]

    public ActionResult ChangeDiscount([FromQuery]double discount, [FromQuery] string productName)
    {
        if(discount < 0 | discount > 100)
        {
            return BadRequest("Ingrese un descuento superior a 0 e ineferior a 100");
        }
        _productService.ChangeDiscount(discount, productName);
        return Ok("Se cambió el descuento");
    }


    [HttpPatch("happyhour")]
    public ActionResult<string> ApplyHappyHour([FromQuery]string productName)
    {
        var response =_productService.ApplyHappyHour(productName);
        return Ok(response);
    }


    [HttpGet("pricewithdiscount")]
    [AllowAnonymous]
    public ActionResult<ProductPriceDto> GetProductPriceWithDiscount([FromQuery] string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
        {
            return BadRequest("Debe proporcionar el nombre del producto");
        }

        var result = _productService.GetProductFinalPrice(productName);

        if (result == null)
        {
            return NotFound($"No se encontró el producto '{productName}'");
        }

        return Ok(result);

    }
}
