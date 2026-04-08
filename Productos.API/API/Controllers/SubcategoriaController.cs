using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase, ISubCategoriaController
    {
        private readonly ILogger<SubCategoriaController> _logger;
        private readonly ISubCategoriaFlujo _subCategoriaFlujo;

        public SubCategoriaController(
            ILogger<SubCategoriaController> logger,
            ISubCategoriaFlujo subCategoriaFlujo)
        {
            _logger = logger;
            _subCategoriaFlujo = subCategoriaFlujo;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(SubCategoriaRequest subcategoria)
        {
            var resultado = await _subCategoriaFlujo.Agregar(subcategoria);
            return CreatedAtAction(nameof(ObtenerId), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, SubCategoriaRequest subcategoria)
        {
            var resultado = await _subCategoriaFlujo.Editar(Id, subcategoria);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            var resultado = await _subCategoriaFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _subCategoriaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("porCategoria/{IdCategoria}")]
        public async Task<IActionResult> ObtenerPorCategoria(Guid IdCategoria)
        {
            var resultado = await _subCategoriaFlujo.ObtenerPorCategoria(IdCategoria);
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerId(Guid Id)
        {
            var resultado = await _subCategoriaFlujo.ObtenerId(Id);
            return Ok(resultado);
        }
    }
}