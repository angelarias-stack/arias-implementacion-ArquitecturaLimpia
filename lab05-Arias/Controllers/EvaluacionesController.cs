using Microsoft.AspNetCore.Mvc;
using lab05_Arias.Models;
using lab05_Arias.Services;

namespace lab05_Arias.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacionService _evaluacionService;

        public EvaluacionesController(IEvaluacionService evaluacionService)
        {
            _evaluacionService = evaluacionService;
        }

        // GET: api/Evaluaciones
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var evaluaciones = await _evaluacionService.ObtenerTodasAsync();
            return Ok(evaluaciones);
        }

        // GET: api/Evaluaciones/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evaluacion = await _evaluacionService.ObtenerPorIdAsync(id);
            if (evaluacion == null)
            {
                return NotFound(new { mensaje = $"No se encontró la evaluación con ID {id}" });
            }
            return Ok(evaluacion);
        }

        // POST: api/Evaluaciones
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Evaluacione evaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaEvaluacion = await _evaluacionService.CrearEvaluacionAsync(evaluacion);
            return CreatedAtAction(nameof(GetById), new { id = nuevaEvaluacion.IdEvaluacion }, nuevaEvaluacion);
        }

        // PUT: api/Evaluaciones/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Evaluacione evaluacion)
        {
            var actualizada = await _evaluacionService.ActualizarEvaluacionAsync(id, evaluacion);
            if (!actualizada)
            {
                return NotFound(new { mensaje = $"No se encontró la evaluación con ID {id} para actualizar" });
            }
            return NoContent();
        }

        // DELETE: api/Evaluaciones/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminada = await _evaluacionService.EliminarEvaluacionAsync(id);
            if (!eliminada)
            {
                return NotFound(new { mensaje = $"No se encontró la evaluación con ID {id} para eliminar" });
            }
            return NoContent();
        }
    }
