using DiscountApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscountApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController : ControllerBase
{
    private readonly List<DiscountModel> discounts =
        [
            new(){ Id=1, ProductId = 1, DiscountAmount = 10m},
            new(){ Id=2, ProductId = 2, DiscountAmount = 30m},
            new(){ Id=3, ProductId = 3, DiscountAmount = 40m},
        ];

    [HttpGet("{id}")]
    public ActionResult<DiscountModel> GetDiscountByProductId(int id)
    {
        var discount = discounts.Find(discount => discount.ProductId == id);

        if (discount is not null)
        {
            return Ok(discount);
        }

        return NotFound();
    }
}
