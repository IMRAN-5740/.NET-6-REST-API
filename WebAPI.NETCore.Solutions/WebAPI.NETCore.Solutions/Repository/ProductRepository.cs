using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using WebAPI.NETCore.Solutions.Data;
using WebAPI.NETCore.Solutions.Interfaces.Repository;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
