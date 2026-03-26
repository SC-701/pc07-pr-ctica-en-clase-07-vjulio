using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase, ICategoriaController
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaFlujo _categoriaFlujo;

        public CategoriaController(
            ILogger<CategoriaController> logger,
            ICategoriaFlujo categoriaFlujo)
        {
            _logger = logger;
            _categoriaFlujo = categoriaFlujo;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(CategoriaRequest categoria)
        {
            var resultado = await _categoriaFlujo.Agregar(categoria);
            return CreatedAtAction(nameof(ObtenerId), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, CategoriaRequest categoria)
        {
            var resultado = await _categoriaFlujo.Editar(Id, categoria);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            var resultado = await _categoriaFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _categoriaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerId(Guid Id)
        {
            var resultado = await _categoriaFlujo.ObtenerId(Id);
            return Ok(resultado);
        }
    }
}