using Microsoft.EntityFrameworkCore;
using WareStoreAPI.Models;

namespace WareStoreAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductData> ProductData { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}
