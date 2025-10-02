using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBAPIs.DAO;
using WEBAPIs.Models;

namespace WEBAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsControllers : ControllerBase
    {
        private readonly AppDbcontext _appDbcontext;

        public ProductsControllers(AppDbcontext appDbcontext)
        {
            this._appDbcontext = appDbcontext;
        }


        //Get product by id
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _appDbcontext.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var listProducts = _appDbcontext.Products.ToList();
            return Ok(listProducts);
        }


        //Create new product
        [HttpPost]
        public IActionResult CreateNewProduct([FromBody] Products products)
        {
            if (products == null) return BadRequest();
            _appDbcontext.Products.Add(products);
            _appDbcontext.SaveChanges();
            return Ok(products);
        }

        //Update product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Products products)
        {
            if (id != products.Id) return BadRequest();
            var existingProduct = _appDbcontext.Products.Find(id);
            if (existingProduct == null) return NotFound("Product not found");
            existingProduct.Name = products.Name;
            existingProduct.Price = products.Price;
            existingProduct.quantity = products.quantity;
            _appDbcontext.Products.Update(existingProduct);
            _appDbcontext.SaveChanges();
            return Ok(existingProduct);
        }

        //Delete product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _appDbcontext.Products.Find(id);
            if (existingProduct == null) return NotFound("Product not found");
            _appDbcontext.Products.Remove(existingProduct);
            _appDbcontext.SaveChanges();
            return Ok("Product deleted");
        }
    }
}