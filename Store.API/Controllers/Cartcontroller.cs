using Microsoft.AspNetCore.Mvc;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Cartcontroller : ControllerBase
    {
        private ICartService _cartService;

        public Cartcontroller(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _cartService.CartDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CartCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _cartService.AddToCart(model))
                return Ok("Success");
            else
                return UnprocessableEntity();
        }
    }
}