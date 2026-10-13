using Microsoft.AspNetCore.Mvc;
using lab05_Arias.Models;
using lab05_Arias.Services;

namespace lab05_Arias.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesoresController : ControllerBase
{
    private readonly IProfesorService _profesorService;

    public ProfesoresController(IProfesorService profesorService)
    {
        _profesorService = profesorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _profesorService.ObtenerTodosAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var profesor = await _profesorService.ObtenerPorIdAsync(id);
        if (profesor == null) return NotFound(new { mensaje = $"Profesor con ID {id} no encontrado" });
        return Ok(profesor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Profesore profesor)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var nuevo = await _profesorService.CrearProfesorAsync(profesor);
        return Ok(nuevo);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Profesore profesor)
    {
        var actualizado = await _profesorService.ActualizarProfesorAsync(id, profesor);
        if (!actualizado) return NotFound(new { mensaje = $"Profesor con ID {id} no encontrado" });
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _profesorService.EliminarProfesorAsync(id);
        if (!eliminado) return NotFound(new { mensaje = $"Profesor con ID {id} no encontrado" });
        return NoContent();
    }
}