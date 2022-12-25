using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebAPI.NETCore.Solutions.Data;
using WebAPI.NETCore.Solutions.Interfaces.Manager;
using WebAPI.NETCore.Solutions.Manager;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

       
        IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
 
            _productManager = productManager;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            var products = _productManager.GetAll().ToList();
            return products;
        }


        [HttpGet("id")]
        public Product GetById(int id)
        {
            return _productManager.GetById(id);
        }

        [HttpPost] 
        public Product CreateProduct(Product product)
        {
            bool isSaved=_productManager.Add(product);
            if(isSaved)
            { 
                return product;
            }
            return null;
           
        }

        [HttpPut("EditProduct")]
      
        public Product EditProduct(Product product)
        {
            if(product == null)
            {
                return null;
            }
            bool isUpate = _productManager.Update(product);
            if(isUpate)
            {
                return product;
            }
            return null;
        }



    }
}
