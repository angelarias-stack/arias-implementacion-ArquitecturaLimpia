using Microsoft.AspNetCore.Mvc;
using lab05_Arias.Models;
using lab05_Arias.Services;

namespace lab05_Arias.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudiantesController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudiantes = await _estudianteService.ObtenerTodosAsync();
            return Ok(estudiantes);
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiante = await _estudianteService.ObtenerPorIdAsync(id);
            if (estudiante == null)
            {
                return NotFound(new { mensaje = $"No se encontró el estudiante con ID {id}" });
            }
            return Ok(estudiante);
        }

        // POST: api/Estudiantes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoEstudiante = await _estudianteService.CrearEstudianteAsync(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEstudiante.IdEstudiante }, nuevoEstudiante);
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Estudiante estudiante)
        {
            var actualizado = await _estudianteService.ActualizarEstudianteAsync(id, estudiante);
            if (!actualizado)
            {
                return NotFound(new { mensaje = $"No se encontró el estudiante con ID {id} para actualizar" });
            }
            return NoContent(); // 204 No Content cuando la actualización fue exitosa
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _estudianteService.EliminarEstudianteAsync(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = $"No se encontró el estudiante con ID {id} para eliminar" });
            }
            return NoContent();
        }
    }