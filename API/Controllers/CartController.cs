using BLL.Abstracts;
using BLL.Concretes;
using BLL.DTO;
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
        public async Task <IActionResult> AddToCart(MovieDTO movie)
        {
           
            var result= await _cart.AddToCart(movie);
            if (result.Status)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task< IActionResult> GetCartItems()
        {

            return Ok(_cart.GetCartItems()) ;
        }

        [HttpDelete]
        public async Task< IActionResult> RemoveFromCart(MovieDTO movie)
        {
            return Ok();
        }

    }
}
