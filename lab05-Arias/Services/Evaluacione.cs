using lab05_Arias.Models;
using lab05_Arias.Repositories;

namespace lab05_Arias.Services;

    public class EvaluacionService : IEvaluacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EvaluacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Evaluacione>> ObtenerTodasAsync()
        {
            return await _unitOfWork.Repository<Evaluacione>().GetAllAsync();
        }

        public async Task<Evaluacione?> ObtenerPorIdAsync(int id)
        {
            return await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
        }

        public async Task<Evaluacione> CrearEvaluacionAsync(Evaluacione evaluacion)
        {
            await _unitOfWork.Repository<Evaluacione>().AddAsync(evaluacion);
            await _unitOfWork.SaveChangesAsync();
            return evaluacion;
        }

        public async Task<bool> ActualizarEvaluacionAsync(int id, Evaluacione evaluacionActualizada)
        {
            var evaluacion = await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
            if (evaluacion == null) return false;

            evaluacion.Calificacion = evaluacionActualizada.Calificacion;
            evaluacion.Fecha = evaluacionActualizada.Fecha;
            evaluacion.IdEstudiante = evaluacionActualizada.IdEstudiante;
            evaluacion.IdCurso = evaluacionActualizada.IdCurso;

            _unitOfWork.Repository<Evaluacione>().Update(evaluacion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarEvaluacionAsync(int id)
        {
            var evaluacion = await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
            if (evaluacion == null) return false;

            _unitOfWork.Repository<Evaluacione>().Delete(evaluacion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
