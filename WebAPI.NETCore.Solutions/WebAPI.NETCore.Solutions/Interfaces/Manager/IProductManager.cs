using EF.Core.Repository.Interface.Manager;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Interfaces.Manager
{
    public interface IProductManager:ICommonManager<Product>
    {
        public Product GetById(int id);
    }
}
