using StockApi.Data.Context;
using StockApi.Data.Unitofwork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApi.Data.Unitofwork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool dispose;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        protected void Clear(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }
    }
}
