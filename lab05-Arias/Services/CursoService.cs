using  lab05_Arias.Models;
using lab05_Arias.Repositories;

namespace lab05_Arias.Services;

public class CursoService : ICursoService
{
    private readonly IUnitOfWork _unitOfWork;

    public CursoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Curso>> ObtenerTodosAsync()
    {
        // Usamos el repositorio genérico instanciado dinámicamente para 'Curso'
        return await _unitOfWork.Repository<Curso>().GetAllAsync();
    }

    public async Task<Curso?> ObtenerPorIdAsync(int id)
    {
        return await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
    }

    public async Task<Curso> CrearCursoAsync(Curso curso)
    {
        await _unitOfWork.Repository<Curso>().AddAsync(curso);
        await _unitOfWork.SaveChangesAsync();
        return curso;
    }

    public async Task<bool> ActualizarCursoAsync(int id, Curso cursoActualizado)
    {
        var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
        if (curso == null) return false;

        curso.Nombre = cursoActualizado.Nombre;
        curso.Descripcion = cursoActualizado.Descripcion;
        curso.Creditos = cursoActualizado.Creditos;

        _unitOfWork.Repository<Curso>().Update(curso);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarCursoAsync(int id)
    {
        var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
        if (curso == null) return false;

        _unitOfWork.Repository<Curso>().Delete(curso);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}