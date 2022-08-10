using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestLunch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {
        private IRestauranteBAC _irestauranteBAC;

        public RestauranteController(IRestauranteBAC irestauranteBAC)
        {
            _irestauranteBAC = irestauranteBAC;
        }

        [HttpGet("getRestaurante")]        
        public async Task<IActionResult> GetRestaurante()
        {
            List<Restaurante> restaurante = await _irestauranteBAC.GetRestaurante();            
            return Ok(restaurante);
        }
        
        [HttpPost("cadastrarRestaurante")]
        public async Task<IActionResult> CreateRestaurante([FromBody] Restaurante restaurante)
        {
            string response = await _irestauranteBAC.CreateRestaurante(restaurante);
            if (nameof(Message.menssageFailure) != null) return Ok(response);
            return BadRequest("Voto não salvo com sucesso");                     
        }
    }
}
