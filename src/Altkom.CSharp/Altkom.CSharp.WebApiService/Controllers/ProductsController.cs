using Altkom.CSharp.EFServices;
using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Altkom.CSharp.WebApiService.Controllers
{
    // signal-r (websocket)

    public class ProductsController : ApiController
    {
        private readonly IProductService productService;

        public ProductsController()
            : this(new EFProductService(new MyContext()))
        {
        }

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var product = productService.Get(id);

            return Ok(product);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var products = productService.Get();

            return Ok(products);
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> Get()
        //{
        //    var products = await productService.GetAsync();

        //    return Ok(products);
        //}

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            productService.Add(product);

            return Created("", product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            productService.Remove(id);

            return Ok();
        }
    }
}