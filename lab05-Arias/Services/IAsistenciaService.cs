using lab05_Arias.Models;

namespace lab05_Arias.Services;

    public interface IAsistenciaService
    {
        Task<IEnumerable<Asistencia>> ObtenerTodasAsync();
        Task<Asistencia?> ObtenerPorIdAsync(int id);
        Task<Asistencia> CrearAsistenciaAsync(Asistencia asistencia);
        Task<bool> ActualizarAsistenciaAsync(int id, Asistencia asistencia);
        Task<bool> EliminarAsistenciaAsync(int id);
    }
