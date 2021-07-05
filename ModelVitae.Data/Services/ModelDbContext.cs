using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelVitae.Data.Models;

namespace ModelVitae.Data.Services
{
    public class ModelDbContext : DbContext
    {
        private readonly IConfiguration config;

        public ModelDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        public DbSet<Model> Models { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("ModelVitae"));
        }
    }
}
