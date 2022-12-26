using EF.Core.Repository.Interface.Manager;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Interfaces.Manager
{
    public interface IProductManager:ICommonManager<Product>
    {
        public Product GetById(int id);
        public ICollection<Product> SearchFixed(string title);
        public ICollection<Product> SearchContains(string text);
        public ICollection<Product> PagingProduct(int page,int pageSize);
    }
}
