using Loyalty.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options): base(options) { }
        public DbSet<Users> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
