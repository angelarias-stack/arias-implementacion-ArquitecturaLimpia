using lab05_Arias.Models;

namespace lab05_Arias.Services;

public interface IProfesorService
{
    Task<IEnumerable<Profesore>> ObtenerTodosAsync();
    Task<Profesore?> ObtenerPorIdAsync(int id);
    Task<Profesore> CrearProfesorAsync(Profesore profesor);
    Task<bool> ActualizarProfesorAsync(int id, Profesore profesor);
    Task<bool> EliminarProfesorAsync(int id);
}