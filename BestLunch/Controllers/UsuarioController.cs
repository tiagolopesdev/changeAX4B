using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestLunch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioBAC _iUsuarioBAC;

        public UsuarioController(IUsuarioBAC iUsuarioBAC)
        {
            _iUsuarioBAC = iUsuarioBAC;
        }

        [HttpGet("getUsuario")]
        public async Task<IActionResult> GetUsuario()
        {
            List<Usuario> usuario = await _iUsuarioBAC.GetUsuario();
            return Ok(usuario);
        }

        [HttpPost("cadastrarUsuario")]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        {
            Usuario response = await _iUsuarioBAC.CreateUsuario(usuario);
            return Ok(response);
        }
    }
}
