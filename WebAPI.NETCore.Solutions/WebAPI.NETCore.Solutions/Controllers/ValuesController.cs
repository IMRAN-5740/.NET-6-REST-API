using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.NETCore.Solutions.Data;
using WebAPI.NETCore.Solutions.Models;

namespace WebAPI.NETCore.Solutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


   
    public class ValuesController : ControllerBase
    {

        ApplicationDbContext _dbContext;
        public ValuesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


      
        [HttpGet]
       
        public string GetFullName()
        {
            return "Mohammad Abdullah Al Imran";
        }

        [HttpGet]
        [Route("AllProducts")]
        public List<Product> GetAllProducts()
        {
            var products=_dbContext.Products.ToList();
            return products;
        }
    }
}
