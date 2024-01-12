using BLL.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cart;

        public CartController( ICartService cart)
        {
           _cart = cart;
        }
        [HttpPost]
        public IActionResult AddToCart(int movieId)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            return Ok(_cart.GetCartItems());
        }

        [HttpDelete]
        public IActionResult RemoveFromCart(int movieId)
        {
            return Ok();
        }

    }
}
