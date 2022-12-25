using EF.Core.Repository.Interface.Repository;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Interfaces.Repository
{
    public interface IProductRepository:ICommonRepository<Product>
    {
    }
}
