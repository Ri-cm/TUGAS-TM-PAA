using Microsoft.EntityFrameworkCore;
using Tugas_PAA.Models;

namespace Tugas_PAA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Books> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
