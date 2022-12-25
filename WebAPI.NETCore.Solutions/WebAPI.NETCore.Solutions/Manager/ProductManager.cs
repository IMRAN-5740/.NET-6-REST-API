using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using WebAPI.NETCore.Solutions.Data;
using WebAPI.NETCore.Solutions.Interfaces.Manager;
using WebAPI.NETCore.Solutions.Models;
using WebAPI.NETCore.Solutions.Repository;

namespace WebAPI.NETCore.Solutions.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        
        public ProductManager( ApplicationDbContext _dbContext) : base(new ProductRepository(_dbContext))
        {
           
        }
    }
}
