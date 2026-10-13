using Microsoft.AspNetCore.Mvc;
using lab05_Arias.Models;
using lab05_Arias.Services;


namespace lab05_Arias.Controllers;

[ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cursos = await _cursoService.ObtenerTodosAsync();
            return Ok(cursos);
        }

        // GET: api/Cursos/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _cursoService.ObtenerPorIdAsync(id);
            if (curso == null)
            {
                return NotFound(new { mensaje = $"No se encontró el curso con ID {id}" });
            }
            return Ok(curso);
        }

        // POST: api/Cursos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoCurso = await _cursoService.CrearCursoAsync(curso);
            return CreatedAtAction(nameof(GetById), new { id = nuevoCurso.IdCurso }, nuevoCurso);
        }

        // PUT: api/Cursos/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Curso curso)
        {
            var actualizado = await _cursoService.ActualizarCursoAsync(id, curso);
            if (!actualizado)
            {
                return NotFound(new { mensaje = $"No se encontró el curso con ID {id} para actualizar" });
            }
            return NoContent();
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _cursoService.EliminarCursoAsync(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = $"No se encontró el curso con ID {id} para eliminar" });
            }
            return NoContent();
        }
    }