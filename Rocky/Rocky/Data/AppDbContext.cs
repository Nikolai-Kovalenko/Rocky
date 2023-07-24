using Microsoft.EntityFrameworkCore;
using Rocky.Models;
using System.Reflection.Metadata.Ecma335;

namespace Rocky.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
