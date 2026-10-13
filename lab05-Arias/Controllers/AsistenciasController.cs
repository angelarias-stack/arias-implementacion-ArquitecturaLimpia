using Microsoft.AspNetCore.Mvc;
using lab05_Arias.Models;
using lab05_Arias.Services;

namespace lab05_Arias.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciasController : ControllerBase
    {
        private readonly IAsistenciaService _asistenciaService;

        public AsistenciasController(IAsistenciaService asistenciaService)
        {
            _asistenciaService = asistenciaService;
        }

        // GET: api/Asistencias
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asistencias = await _asistenciaService.ObtenerTodasAsync();
            return Ok(asistencias);
        }

        // GET: api/Asistencias/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asistencia = await _asistenciaService.ObtenerPorIdAsync(id);
            if (asistencia == null)
            {
                return NotFound(new { mensaje = $"No se encontró la asistencia con ID {id}" });
            }
            return Ok(asistencia);
        }

        // POST: api/Asistencias
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Asistencia asistencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaAsistencia = await _asistenciaService.CrearAsistenciaAsync(asistencia);
            return CreatedAtAction(nameof(GetById), new { id = nuevaAsistencia.IdAsistencia }, nuevaAsistencia);
        }

        // PUT: api/Asistencias/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Asistencia asistencia)
        {
            var actualizada = await _asistenciaService.ActualizarAsistenciaAsync(id, asistencia);
            if (!actualizada)
            {
                return NotFound(new { mensaje = $"No se encontró la asistencia con ID {id} para actualizar" });
            }
            return NoContent();
        }

        // DELETE: api/Asistencias/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminada = await _asistenciaService.EliminarAsistenciaAsync(id);
            if (!eliminada)
            {
                return NotFound(new { mensaje = $"No se encontró la asistencia con ID {id} para eliminar" });
            }
            return NoContent();
        }
    }
