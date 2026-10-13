using lab05_Arias.Models;
using lab05_Arias.Repositories;

namespace lab05_Arias.Services;


    public class ProfesorService : IProfesorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Profesore>> ObtenerTodosAsync()
        {
            return await _unitOfWork.Repository<Profesore>().GetAllAsync();
        }

        public async Task<Profesore?> ObtenerPorIdAsync(int id)
        {
            return await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
        }

        public async Task<Profesore> CrearProfesorAsync(Profesore profesor)
        {
            await _unitOfWork.Repository<Profesore>().AddAsync(profesor);
            await _unitOfWork.SaveChangesAsync();
            return profesor;
        }

        public async Task<bool> ActualizarProfesorAsync(int id, Profesore profesorActualizado)
        {
            var profesor = await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
            if (profesor == null) return false;

            profesor.Nombre = profesorActualizado.Nombre;
            profesor.Especialidad = profesorActualizado.Especialidad;
            profesor.Correo = profesorActualizado.Correo;

            _unitOfWork.Repository<Profesore>().Update(profesor);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarProfesorAsync(int id)
        {
            var profesor = await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
            if (profesor == null) return false;

            _unitOfWork.Repository<Profesore>().Delete(profesor);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
