using Microsoft.AspNetCore.Mvc;
using lab05_Arias.Models;
using lab05_Arias.Services;


namespace lab05_Arias.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MateriasController : ControllerBase
{
    private readonly IMateriaService _materiaService;

    public MateriasController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _materiaService.ObtenerTodasAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var materia = await _materiaService.ObtenerPorIdAsync(id);
        if (materia == null) return NotFound(new { mensaje = $"Materia con ID {id} no encontrada" });
        return Ok(materia);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Materia materia)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var nueva = await _materiaService.CrearMateriaAsync(materia);
        return Ok(nueva);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Materia materia)
    {
        var actualizada = await _materiaService.ActualizarMateriaAsync(id, materia);
        if (!actualizada) return NotFound(new { mensaje = $"Materia con ID {id} no encontrada" });
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminada = await _materiaService.EliminarMateriaAsync(id);
        if (!eliminada) return NotFound(new { mensaje = $"Materia con ID {id} no encontrada" });
        return NoContent();
    }
}