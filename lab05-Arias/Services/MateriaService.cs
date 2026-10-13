using lab05_Arias.Models;
using lab05_Arias.Repositories;

namespace lab05_Arias.Services;


    public class MateriaService : IMateriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Materia>> ObtenerTodasAsync()
        {
            return await _unitOfWork.Repository<Materia>().GetAllAsync();
        }

        public async Task<Materia?> ObtenerPorIdAsync(int id)
        {
            return await _unitOfWork.Repository<Materia>().GetByIdAsync(id);
        }

        public async Task<Materia> CrearMateriaAsync(Materia materia)
        {
            await _unitOfWork.Repository<Materia>().AddAsync(materia);
            await _unitOfWork.SaveChangesAsync();
            return materia;
        }

        public async Task<bool> ActualizarMateriaAsync(int id, Materia materiaActualizada)
        {
            var materia = await _unitOfWork.Repository<Materia>().GetByIdAsync(id);
            if (materia == null) return false;

            materia.Nombre = materiaActualizada.Nombre;
            materia.Descripcion = materiaActualizada.Descripcion;
            materia.IdCurso = materiaActualizada.IdCurso;

            _unitOfWork.Repository<Materia>().Update(materia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarMateriaAsync(int id)
        {
            var materia = await _unitOfWork.Repository<Materia>().GetByIdAsync(id);
            if (materia == null) return false;

            _unitOfWork.Repository<Materia>().Delete(materia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
