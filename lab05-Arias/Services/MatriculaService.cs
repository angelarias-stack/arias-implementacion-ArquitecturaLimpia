
using lab05_Arias.Models;
using lab05_Arias.Repositories;

namespace lab05_Arias.Services;




    public class MatriculaService : IMatriculaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Matricula>> ObtenerTodasAsync()
        {
            return await _unitOfWork.Repository<Matricula>().GetAllAsync();
        }

        public async Task<Matricula?> ObtenerPorIdAsync(int id)
        {
            return await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
        }

        public async Task<Matricula> CrearMatriculaAsync(Matricula matricula)
        {
            await _unitOfWork.Repository<Matricula>().AddAsync(matricula);
            await _unitOfWork.SaveChangesAsync();
            return matricula;
        }

        public async Task<bool> ActualizarMatriculaAsync(int id, Matricula matriculaActualizada)
        {
            var matricula = await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
            if (matricula == null) return false;

            matricula.Semestre = matriculaActualizada.Semestre;
            matricula.IdEstudiante = matriculaActualizada.IdEstudiante;
            matricula.IdCurso = matriculaActualizada.IdCurso;

            _unitOfWork.Repository<Matricula>().Update(matricula);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarMatriculaAsync(int id)
        {
            var matricula = await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
            if (matricula == null) return false;

            _unitOfWork.Repository<Matricula>().Delete(matricula);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
