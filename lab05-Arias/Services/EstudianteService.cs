using  lab05_Arias.Models;
using lab05_Arias.Repositories;

namespace lab05_Arias.Services;

public class EstudianteService : IEstudianteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Estudiante>> ObtenerTodosAsync()
        {
            return await _unitOfWork.Repository<Estudiante>().GetAllAsync();
        }

        public async Task<Estudiante?> ObtenerPorIdAsync(int id)
        {
            return await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
        }

        public async Task<Estudiante> CrearEstudianteAsync(Estudiante estudiante)
        {
            // Agrega mediante el repositorio dinámico
            await _unitOfWork.Repository<Estudiante>().AddAsync(estudiante);
            
            // Confirma la transacción con SaveChangesAsync del UnitOfWork
            await _unitOfWork.SaveChangesAsync();
            return estudiante;
        }

        public async Task<bool> ActualizarEstudianteAsync(int id, Estudiante estudianteActualizado)
        {
            var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
            if (estudiante == null) return false;

            estudiante.Nombre = estudianteActualizado.Nombre;
            estudiante.Edad = estudianteActualizado.Edad;
            estudiante.Direccion = estudianteActualizado.Direccion;
            estudiante.Telefono = estudianteActualizado.Telefono;
            estudiante.Correo = estudianteActualizado.Correo;

            _unitOfWork.Repository<Estudiante>().Update(estudiante);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarEstudianteAsync(int id)
        {
            var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
            if (estudiante == null) return false;

            _unitOfWork.Repository<Estudiante>().Delete(estudiante);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }