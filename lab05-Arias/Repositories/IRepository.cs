using System.Linq.Expressions;


namespace lab05_Arias.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        
        // Agregar entidad sin guardar cambios inmediatamente (se delega al UnitOfWork)
        Task AddAsync(TEntity entity);
        
        // Agregar entidad guardando cambios de forma directa
        Task AddAndSaveAsync(TEntity entity);
        
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}