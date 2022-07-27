using StockApi.Data.Context;
using StockApi.Data.Model;
using StockApi.Data.Repository.Abstract;

namespace StockApi.Data.Repository.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
