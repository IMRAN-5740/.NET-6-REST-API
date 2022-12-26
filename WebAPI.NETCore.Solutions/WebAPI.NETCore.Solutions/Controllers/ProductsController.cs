using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebAPI.NETCore.Solutions.Data;
using WebAPI.NETCore.Solutions.Interfaces.Manager;
using WebAPI.NETCore.Solutions.Manager;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var products = _productManager.GetAll().ToList();
            return products;
        }


        [HttpGet("id")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productManager.GetById(id);
            if(product==null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("product")]
       // [Route("CreateProduct")]
        public  ActionResult<Product>CreateProduct(Product product)
        {
            bool isSaved = _productManager.Add(product);
            if (isSaved)
            {
                return Ok("Product Create Has been Successfully");
            }
            return BadRequest("Not Create");

        }

        [HttpPut("product")]
     //  [Route("product")]
        public ActionResult<Product> EditProduct(Product product)
        {
            
            if (product == null)
            {
                return NotFound();
            }

            bool isUpate = _productManager.Update(product);
            if (isUpate)
            {
                return Ok(product);
            }
            return BadRequest("Product Not Updated");
        }

        [HttpDelete("id")]
       // [Route("DeleteProduct")]
        public ActionResult<string> Delete( int id)
        {

            var products = _productManager.GetById(id);
            if (products == null)
            {
                return BadRequest("Corresponding Product Not Found"); 
            }
            bool isDelete = _productManager.Delete(products);
            if (isDelete)
            {
                return Ok("Product Deleted Successfully");
            }
            return BadRequest("Product Not Deleted");

        }


    }
}
