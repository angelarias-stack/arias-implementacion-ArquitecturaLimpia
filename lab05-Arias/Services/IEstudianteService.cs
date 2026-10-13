using lab05_Arias.Models;

namespace lab05_Arias.Services;

public interface IEstudianteService
{
    Task<IEnumerable<Estudiante>> ObtenerTodosAsync();
    Task<Estudiante?> ObtenerPorIdAsync(int id);
    Task<Estudiante> CrearEstudianteAsync(Estudiante estudiante);
    Task<bool> ActualizarEstudianteAsync(int id, Estudiante estudiante);
    Task<bool> EliminarEstudianteAsync(int id);
}