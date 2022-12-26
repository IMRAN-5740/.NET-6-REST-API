using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;
using WebAPI.NETCore.Solutions.Data;
using WebAPI.NETCore.Solutions.Interfaces.Manager;
using WebAPI.NETCore.Solutions.Manager;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : BaseController
    {


        IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = _productManager.GetAll().ToList();
                // return Ok(products);
                return CustomResult("Product Loaded Successfully",products,HttpStatusCode.Accepted); 
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productManager.GetById(id);
                if (product == null)
                {
                    return CustomResult("Product Not Found",product,HttpStatusCode.NotFound);
                }

                return CustomResult("Product Found Successfully", product, HttpStatusCode.OK);
            }
           
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("product")]
       // [Route("CreateProduct")]
        public  IActionResult CreateProduct(Product product)
        {
            try
            {
                product.DateTime = DateTime.Now;
                bool isSaved = _productManager.Add(product);
                if (isSaved)
                {
                    return  CustomResult("Product has been Created Successfully", product, HttpStatusCode.OK);
                }
                return  CustomResult("Product not Create", product, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }


        }

        [HttpPut("product")]
     //  [Route("product")]
        public IActionResult EditProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return CustomResult("Product Not Found", product, HttpStatusCode.NotFound);
                }
                if (product.Id == 0)
                {
                    
                    return CustomResult("Request Id is Missing", product, HttpStatusCode.BadRequest);
                }

                bool isUpate = _productManager.Update(product);
                if (isUpate)
                {
                    return CustomResult("Product has been Updated Successfully", product, HttpStatusCode.OK);
                }
              
                return CustomResult("Product Not Updated", product, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message,  HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete("id")]
       // [Route("DeleteProduct")]
        public IActionResult Delete( int id)
        {
            try
            {
                    var products = _productManager.GetById(id);
                    if (products == null)
                    {
                        return BadRequest("Corresponding Product Not Found"); 
                    }
                    bool isDelete = _productManager.Delete(products);
                    if (isDelete)
                    {
                    return CustomResult("Product has been Deleted Successfully", products, HttpStatusCode.OK);
                }
                return CustomResult("Product Not Deleted", products, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }


    }
}
