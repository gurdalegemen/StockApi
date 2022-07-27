using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using StockApi.Data.Model;
using System.Data;
using System.Reflection;

namespace StockApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
