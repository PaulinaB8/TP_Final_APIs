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

    



    [HttpGet]
    [Route("{idCategory}")]
    public ActionResult<IEnumerable<ProductDto>> GetProductsByCategory(int idCategory)
    {
        var response=_productService.GetProductsByCategory(idCategory);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }



    [HttpGet]
    [Route("{idProduct}")]
    public ActionResult<ProductDto> GetProduct(int idProduct)
    {
        var response = _productService.GetProduct(idProduct);
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetFavouriteProducts()
    {
        var response = _productService.GetFavouriteProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetDiscountProducts()
    {
        var response = _productService.GetDiscountProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetHappyHourProducts()
    {
        var response = _productService.GetHappyHourProducts();
        if (response == null)
        {
            return NotFound();
        }
        else return Ok(response);
    }


    [HttpPost]
    public ActionResult CreateProduct([FromBody]CreateAndUpdateProductDto newProduct, int idCategory)
    {
        _productService.CreateProduct(newProduct, idCategory);
        return Ok();

    }

    [HttpDelete]
    [Route("{idProduct}")]
    public ActionResult DeleteProduct(int idProduct)
    {
        _productService.DeleteProduct(idProduct);
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateProduct([FromBody]CreateAndUpdateProductDto updatedProduct, int idProduct)
    {
        _productService.UpdateProduct(updatedProduct, idProduct);
        return Ok();
    }

    [HttpPut]
    [Route("{idProduct}")]
    public ActionResult ChangeDiscount(double discount, int idProduct)
    {
        _productService.ChangeDiscount(discount, idProduct);
        return Ok();
    }


    [HttpPut]
    [Route("{idProduct}")]
    public ActionResult<string> ApplyHappyHour(int idProduct)
    {
        var response =_productService.ApplyHappyHour(idProduct);
        return Ok(response);
    }


}
