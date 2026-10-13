using lab05_Arias.Models;

namespace lab05_Arias.Services;

public interface IMateriaService
{
    Task<IEnumerable<Materia>> ObtenerTodasAsync();
    Task<Materia?> ObtenerPorIdAsync(int id);
    Task<Materia> CrearMateriaAsync(Materia materia);
    Task<bool> ActualizarMateriaAsync(int id, Materia materia);
    Task<bool> EliminarMateriaAsync(int id);
}