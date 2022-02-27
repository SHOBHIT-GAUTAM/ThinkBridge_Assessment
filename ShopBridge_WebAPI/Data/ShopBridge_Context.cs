using Microsoft.EntityFrameworkCore;
using ShopBridge_WebAPI.Domain.Models;

namespace ShopBridge_WebAPI.Data
{
    public class ShopBridge_Context : DbContext
    {
        public ShopBridge_Context(DbContextOptions<ShopBridge_Context> options) :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
    