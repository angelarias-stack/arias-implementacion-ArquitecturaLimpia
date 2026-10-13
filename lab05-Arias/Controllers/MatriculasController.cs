using Microsoft.AspNetCore.Mvc;
using lab05_Arias.Models;
using lab05_Arias.Services;

namespace lab05_Arias.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class MatriculasController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculasController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        // GET: api/Matriculas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matriculas = await _matriculaService.ObtenerTodasAsync();
            return Ok(matriculas);
        }

        // GET: api/Matriculas/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var matricula = await _matriculaService.ObtenerPorIdAsync(id);
            if (matricula == null)
            {
                return NotFound(new { mensaje = $"No se encontró la matrícula con ID {id}" });
            }
            return Ok(matricula);
        }

        // POST: api/Matriculas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaMatricula = await _matriculaService.CrearMatriculaAsync(matricula);
            return CreatedAtAction(nameof(GetById), new { id = nuevaMatricula.IdMatricula }, nuevaMatricula);
        }

        // PUT: api/Matriculas/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Matricula matricula)
        {
            var actualizada = await _matriculaService.ActualizarMatriculaAsync(id, matricula);
            if (!actualizada)
            {
                return NotFound(new { mensaje = $"No se encontró la matrícula con ID {id} para actualizar" });
            }
            return NoContent();
        }

        // DELETE: api/Matriculas/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminada = await _matriculaService.EliminarMatriculaAsync(id);
            if (!eliminada)
            {
                return NotFound(new { mensaje = $"No se encontró la matrícula con ID {id} para eliminar" });
            }
            return NoContent();
        }
    }
