using System.Linq.Expressions;

namespace StockApi.Data.Repository.Abstract
{
    public interface IBaseRepository<Entity > where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllAsync();
        Entity GetByIdAsync(int id);
        Task InsertAsync(Entity entity);
        void UpdateAsync(Entity entity);
        void DeleteAsync(Entity entity);
        Task<IEnumerable<Entity>> FindAsync(Expression<Func<Entity, bool>> expresion);
    }
}
