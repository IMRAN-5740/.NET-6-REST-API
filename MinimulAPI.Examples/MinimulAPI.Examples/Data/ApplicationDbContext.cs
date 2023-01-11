using Microsoft.EntityFrameworkCore;
using MinimulAPI.Examples.Models;

namespace MinimulAPI.Examples.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        } 
        public DbSet<PostModel> PostModels { get; set; }
    }
}
