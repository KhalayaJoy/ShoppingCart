using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Model;
using System.Collections.Generic;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductDbContext _productDbContext;
        public ProductController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _productDbContext.Product.ToListAsync();
        }

        [HttpPut]
        [Route("UpdateStock")]
        public async Task<List<Product>> UpdateStock([FromBody] List<Product> lstdata)
        {
            try
            {
                foreach (var item in lstdata)
                {
                    var qdata = _productDbContext.Product.FirstOrDefault(w => w.Id.Equals(item.Id));
                    if (qdata != null)
                    {
                        qdata.Stock = item.Stock;
                        _productDbContext.Entry(qdata).State = EntityState.Modified;
                        await _productDbContext.SaveChangesAsync();
                    }
                }

                return lstdata;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
