using Microsoft.EntityFrameworkCore;
using StockApi.Data.Context;
using StockApi.Data.Repository.Abstract;
using StockApi.Data.Unitofwork.Abstract;
using StockApi.Data.Unitofwork.Concrete;
using System.Linq.Expressions;

namespace StockApi.Data.Repository.Concrete
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {
        protected readonly AppDbContext Context;
        private DbSet<Entity> ent;
        UnitOfWork unitOfWork;

        public BaseRepository(AppDbContext dbContext)
        {
            this.Context = dbContext;
            this.ent = Context.Set<Entity>();
            unitOfWork = new UnitOfWork(this.Context);
        }
        public async void DeleteAsync(Entity entity)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Entity>> FindAsync(Expression<Func<Entity, bool>> expresion)
        {
            return await ent.Where(expresion).ToListAsync();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await ent.AsNoTracking().ToListAsync();
        }

        public  Entity GetByIdAsync(int id)
        {
            return ent.Find(id);
            //return  ent.FindAsync(id);
        }

        public async Task InsertAsync(Entity entity)
        {
            await ent.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public void UpdateAsync(Entity entity)
        {
            unitOfWork.CompleteAsync();
            ent.Update(entity);
            
        }
    }
}
