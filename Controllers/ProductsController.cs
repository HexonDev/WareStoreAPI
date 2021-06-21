using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.FileProviders;
using WareStoreAPI.Models;
using WareStoreAPI.Services;

namespace WareStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService, IFileProvider fileProvider)
        {
            this._productsService = productsService;
        }

        #region GET METHODS

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productsService.GetProducts());
        }

        [HttpGet("{pid:long}")]
        public IActionResult GetProductById(long pid)
        {
            var product = _productsService.GetProduct(pid);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        #endregion

        #region POST METHODS

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            if (product == null)
                return BadRequest();

            _productsService.AddProduct(product);

            return Ok(product);
        }

        #endregion

        #region PATCH/PUT METHODS

        [HttpPatch("{pid:long}")]
        public IActionResult PatchProduct(long pid, JsonPatchDocument<Product> patchProduct)
        {
            var product = _productsService.GetProduct(pid);

            if (product == null)
                return NotFound();

            patchProduct.ApplyTo(product, ModelState);
            _productsService.UpdateProduct(product);

            return Ok(product);
        }

        [HttpPut("{sid:long}")]
        public IActionResult PutStorage(long sid, Product putProduct)
        {
            if (putProduct == null)
                return BadRequest("Model is null");

            var product = _productsService.GetProduct(sid);

            if (product == null)
                return NotFound();

            product.Name = putProduct.Name;
            product.Amount = putProduct.Amount;
            product.Barcode = putProduct.Barcode;
            product.Data = putProduct.Data;

            _productsService.UpdateProduct(product);

            return Ok(product);
        }

        #endregion

        #region DELETE METHODS

        [HttpDelete("{pid:long}")]
        public IActionResult DeleteProduct(long pid)
        {
            var product = _productsService.GetProduct(pid);

            if (product == null)
                return NotFound();

            _productsService.DeleteProduct(product);

            return Ok();
        }

        #endregion
    }
}
