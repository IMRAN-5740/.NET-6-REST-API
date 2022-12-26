using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using Microsoft.EntityFrameworkCore;
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

        public ICollection<Product> SearchFixed(string title)
        {
            var products = Get(c => c.Name.ToLower() == title.ToLower());
            return products;
        }

        public Product GetById(int id)
        {
            var product=GetFirstOrDefault(c => c.Id == id);
            return product;
        }

        public ICollection<Product> SearchContains(string text)
        {
            text = text.ToLower();
            var products = Get(c=>c.Name.ToLower().Contains(text) || c.Description.ToLower().Contains(text));
            return products;
        }

        public ICollection<Product> PagingProduct(int page,int pageSize)
        {
           if(page <= 1)
            {
                page = 0;
            }
            int totalPage = page * pageSize;
            var products=GetAll().Skip(totalPage).Take(pageSize).ToList();
            return products;
        }
    }
}
