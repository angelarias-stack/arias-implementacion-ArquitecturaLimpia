using lab05_Arias.Models;
using lab05_Arias.Repositories;

namespace lab05_Arias.Services;

    public class AsistenciaService : IAsistenciaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AsistenciaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Asistencia>> ObtenerTodasAsync()
        {
            return await _unitOfWork.Repository<Asistencia>().GetAllAsync();
        }

        public async Task<Asistencia?> ObtenerPorIdAsync(int id)
        {
            return await _unitOfWork.Repository<Asistencia>().GetByIdAsync(id);
        }

        public async Task<Asistencia> CrearAsistenciaAsync(Asistencia asistencia)
        {
            await _unitOfWork.Repository<Asistencia>().AddAsync(asistencia);
            await _unitOfWork.SaveChangesAsync();
            return asistencia;
        }

        public async Task<bool> ActualizarAsistenciaAsync(int id, Asistencia asistenciaActualizada)
        {
            var asistencia = await _unitOfWork.Repository<Asistencia>().GetByIdAsync(id);
            if (asistencia == null) return false;

            asistencia.Fecha = asistenciaActualizada.Fecha;
            asistencia.Estado = asistenciaActualizada.Estado;
            asistencia.IdEstudiante = asistenciaActualizada.IdEstudiante;
            asistencia.IdCurso = asistenciaActualizada.IdCurso;

            _unitOfWork.Repository<Asistencia>().Update(asistencia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsistenciaAsync(int id)
        {
            var asistencia = await _unitOfWork.Repository<Asistencia>().GetByIdAsync(id);
            if (asistencia == null) return false;

            _unitOfWork.Repository<Asistencia>().Delete(asistencia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
