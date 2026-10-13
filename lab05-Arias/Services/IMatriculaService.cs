using lab05_Arias.Models;

namespace lab05_Arias.Services;

    public interface IMatriculaService
    {
        Task<IEnumerable<Matricula>> ObtenerTodasAsync();
        Task<Matricula?> ObtenerPorIdAsync(int id);
        Task<Matricula> CrearMatriculaAsync(Matricula matricula);
        Task<bool> ActualizarMatriculaAsync(int id, Matricula matricula);
        Task<bool> EliminarMatriculaAsync(int id);
    }
