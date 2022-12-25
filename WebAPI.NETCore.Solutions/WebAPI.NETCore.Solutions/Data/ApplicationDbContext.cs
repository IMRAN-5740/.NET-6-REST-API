using Microsoft.EntityFrameworkCore;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> _dbContext):base(_dbContext)
        {


        }

      
        public DbSet<Product> Products { get; set; }

    }
}
