using Microsoft.EntityFrameworkCore;
using MVC_Example.Models;

namespace MVC_Example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
