using System.Collections.Generic;
using Backend_NETCore_Mongodb.Models;
using Backend_NETCore_Mongodb.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_NETCore_Mongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get() =>
            _service.Get();


        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public ActionResult<Product> Get(string id)
        {
            var product = _service.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        [HttpPost]
        public ActionResult<Product> Create(Product model)
        {
            _service.Create(model);

            return CreatedAtRoute("GetProduct", new { id = model.Id.ToString() }, model);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product model)
        {
            var product = _service.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _service.Update(id, model);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = _service.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _service.Remove(product.Id);

            return NoContent();
        }
    }
}