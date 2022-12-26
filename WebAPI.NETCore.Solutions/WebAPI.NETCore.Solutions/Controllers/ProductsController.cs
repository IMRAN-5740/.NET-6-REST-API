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
                var products = _productManager.GetAll().OrderBy(c=>c.Id).ToList();
                // return Ok(products);
                return CustomResult("Product Loaded Successfully",products,HttpStatusCode.Accepted); 
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpGet("title")]
        public IActionResult SearchFixed(string title)
        {
            try
            {
                var products = _productManager.SearchFixed(title).ToList();
                // return Ok(products);
                return CustomResult("Searching Product", products, HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("text")]
        public IActionResult SearchContains(string text)
        {
            try
            {
                var products = _productManager.SearchContains(text).ToList();
                // return Ok(products);
                return CustomResult("Searching Product", products, HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("Descending")]
        public IActionResult GetAllDescending()
        {
            try
            {
                var products = _productManager.GetAll().OrderByDescending(c=>c.DateTime).ToList();
                // return Ok(products);
                return CustomResult("Product Loaded Successfully", products, HttpStatusCode.Accepted);
            }
            catch (Exception ex)
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
                    return CustomResult("Product Not Found", HttpStatusCode.BadRequest);
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

        [HttpGet("page")]
        public IActionResult PagingProduct(int page=1)

        {
            try
            {
                var products = _productManager.PagingProduct(page, 2);
                return CustomResult("Paging Product List Shown Successfully",products,HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }


    }
}
