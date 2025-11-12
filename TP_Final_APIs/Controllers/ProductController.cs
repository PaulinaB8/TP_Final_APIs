using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<IEnumerable<ProductDto>> GetProductsByCategory([FromQuery] string categoryName)
    {
        var response = _productService.GetProductsByCategory(categoryName);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }



    [HttpGet("{idProduct}")]
    [AllowAnonymous]
    public ActionResult<ProductDto> GetProduct([FromRoute] int idProduct)
    {
        var response = _productService.GetProduct(idProduct);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet("favourites")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetFavouriteProducts()
    {
        var response = _productService.GetFavouriteProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet("discountproducts")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetDiscountProducts()
    {
        var response = _productService.GetDiscountProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet("happyhour")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetHappyHourProducts()
    {
        var response = _productService.GetHappyHourProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpPost("{idCategory}")]

    public ActionResult CreateProduct([FromBody]CreateAndUpdateProductDto newProduct, [FromRoute]int idCategory)
    {
        _productService.CreateProduct(newProduct, idCategory);
        return Ok("Producto creado");

    }

    [HttpDelete("{idProduct}")]
    public ActionResult DeleteProduct([FromRoute] int idProduct)
    {
        _productService.DeleteProduct(idProduct);
        return Ok("Producto eliminado");
    }

    [HttpPut("{idProduct}")]
    public ActionResult UpdateProduct([FromBody]CreateAndUpdateProductDto updatedProduct, [FromRoute]int idProduct)
    {
        _productService.UpdateProduct(updatedProduct, idProduct);
        return Ok("Producto editado");
    }

    [HttpPut("discount/{idProduct}")]

    public ActionResult ChangeDiscount([FromQuery]double discount, [FromRoute] int idProduct)
    {
        _productService.ChangeDiscount(discount, idProduct);
        return Ok("Se cambió el descuento");
    }


    [HttpPut("happyhour/{idProduct}")]
    public ActionResult<string> ApplyHappyHour([FromRoute]int idProduct)
    {
        var response =_productService.ApplyHappyHour(idProduct);
        return Ok(response);
    }

}
