using lab05_Arias.Models;

namespace lab05_Arias.Services;

    public interface IEvaluacionService
    {
        Task<IEnumerable<Evaluacione>> ObtenerTodasAsync();
        Task<Evaluacione?> ObtenerPorIdAsync(int id);
        Task<Evaluacione> CrearEvaluacionAsync(Evaluacione evaluacion);
        Task<bool> ActualizarEvaluacionAsync(int id, Evaluacione evaluacion);
        Task<bool> EliminarEvaluacionAsync(int id);
    }
