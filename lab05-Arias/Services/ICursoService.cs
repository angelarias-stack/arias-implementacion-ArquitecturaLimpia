using lab05_Arias.Models;

namespace lab05_Arias.Services;

public interface ICursoService
{
    Task<IEnumerable<Curso>> ObtenerTodosAsync();
    Task<Curso?> ObtenerPorIdAsync(int id);
    Task<Curso> CrearCursoAsync(Curso curso);
    Task<bool> ActualizarCursoAsync(int id, Curso curso);
    Task<bool> EliminarCursoAsync(int id);
}