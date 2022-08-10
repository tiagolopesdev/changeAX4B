using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestLunch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotoController : Controller
    {
        private IVotoBAC _ivotoBAC;

        public VotoController(IVotoBAC ivotoBAC)
        {
            _ivotoBAC = ivotoBAC;
        }

        [HttpGet("getVotos")]        
        public async Task<IActionResult> GetVotos()
        {
            List<Votos> restaurante = await _ivotoBAC.GetVoto();          
            return Ok(restaurante);
        }
        
        [HttpPost("cadastrarVotos")]
        public async Task<IActionResult> CreateVotos([FromBody] Votos votos)
        {
            string response = await _ivotoBAC.CreateVoto(votos);
            if (nameof(Message.menssageFailure) != null) return Ok(response);
            return BadRequest("Voto não salvo com sucesso");
        }
        [HttpGet("ranking")]
        public async Task<IActionResult> GetRanking()
        {
            IEnumerable<Ranking> response = await _ivotoBAC.GetRanking();
            return Ok(response);
        }
        [HttpGet("getFirstElement")]
        public async Task<IActionResult> GetOneRanking()
        {
            Ranking response = await _ivotoBAC.GetOneRanking();
            return Ok(response);
        }
    }
}
