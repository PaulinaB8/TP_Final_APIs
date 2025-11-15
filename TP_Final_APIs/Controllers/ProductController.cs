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
    public ActionResult<IEnumerable<FavouriteProductsDto>> GetFavouriteProducts()
    {
        var response = _productService.GetFavouriteProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet("discountProducts")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductsWithDiscountDto>> GetDiscountProducts()
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
    public ActionResult<IEnumerable<FavouriteProductsDto>> GetHappyHourProducts()
    {
        var response = _productService.GetHappyHourProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpPost]

    public ActionResult CreateProduct([FromBody]CreateProductDto newProduct, [FromQuery] string categoryName)
    {


        _productService.CreateProduct(newProduct, categoryName);
        return Ok("Producto creado");

    }

    [HttpDelete]
    public ActionResult DeleteProduct([FromQuery] string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
            return BadRequest("Debe especificar el nombre del producto.");
        _productService.DeleteProduct(productName);
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
        _productService.ChangeDiscount(discount, productName);
        return Ok("Se cambió el descuento");
    }


    [HttpPatch("happyhour")]
    public ActionResult<string> ApplyHappyHour([FromQuery]string productName)
    {
        var response =_productService.ApplyHappyHour(productName);
        return Ok(response);
    }

<<<<<<< HEAD
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
=======
    [HttpPatch("applydiscount")]
    public ActionResult ApplyDiscountToMultipleProducts([FromBody] List<string> productNames, [FromQuery] double percentage)
    {
        try
        {
            _productService.ApplyDiscountToProducts(productNames, percentage);
            return Ok($"Se aplicó el {percentage}% de descuento a los productos seleccionados");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
>>>>>>> 3bb738d2b0e082a41b14f7d7194d0122ad04bdeb
    }
}
