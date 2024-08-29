using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly List<ProductModel> productList =
        [
            new(){Id = 1, Name = "Product A", Price = 60m},
            new(){Id = 2, Name = "Product B", Price = 160m},
            new(){Id = 3, Name = "Product C", Price = 180m}
        ];

    [HttpGet]
    public ActionResult<List<ProductModel>> GetProducts()
    {
        return Ok(productList);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductModel> GetProduct(int id)
    {
        var product = productList.Find(e => e.Id == id);

        if (product is not null)
        {
            return Ok(product);
        }

        return NotFound();
    }
}
