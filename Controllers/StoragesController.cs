using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.FileProviders;
using WareStoreAPI.Models;
using WareStoreAPI.Services;

namespace WareStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly StoragesService _storagesService;

        public StoragesController(StoragesService storagesService, IFileProvider fileProvider)
        {
            this._storagesService = storagesService;
        }

        #region GET METHODS

        [HttpGet]
        public IActionResult GetStorages()
        {
            //Thread.Sleep(5000);
            return Ok(_storagesService.GetStorages());
        }
        
        [HttpGet("{sid:long}")]
        public IActionResult GetStorageById(long sid)
        {
            var storage = _storagesService.GetStorage(sid);

            if (storage == null)
                return NotFound();

            return Ok(storage);
        }

        [HttpGet("{sid:long}/products")]
        public IActionResult GetStorageProducts(long sid)
        {
            var storage = _storagesService.GetStorage(sid);

            if (storage == null)
                return NotFound();

            return Ok(storage.Products.ToArray());
        }

        #endregion

        #region POST METHODS

        [HttpPost]
        public IActionResult PostStorage(Storage storage)
        {
            if (storage == null)
                return BadRequest(); Debug.Write("2");

            _storagesService.AddStorage(storage);

            return Ok(storage);
        }

        [HttpPost("{sid:long}/products")]
        public IActionResult PostStorageProduct(long sid, Product product)
        {
            if (product == null)
                return BadRequest();

            var storage = _storagesService.GetStorage(sid);

            if (storage == null)
                return NotFound();

            _storagesService.AddStorageProduct(storage, product);

            return Ok(product);
        }

        #endregion

        #region PATCH/PUT METHODS

        [HttpPatch("{sid:long}")]
        public IActionResult PatchStorage(long sid, JsonPatchDocument<Storage> patchStorage)
        {
            if (patchStorage == null)
                return BadRequest();

            var storage = _storagesService.GetStorage(sid);

            if (storage == null)
                return NotFound();

            patchStorage.ApplyTo(storage, ModelState);
            _storagesService.UpdateStorage(storage);

            return Ok(storage);
        }

        [HttpPut("{sid:long}")]
        public IActionResult PutStorage(long sid, Storage putStorage)
        {
            if (putStorage == null)
                return BadRequest("Model is null");

            var storage = _storagesService.GetStorage(sid);

            if (storage == null)
                return NotFound();


            storage.Address = putStorage.Address;
            storage.AddressId = putStorage.Address.Id;
            storage.Name = putStorage.Name;
            storage.Products = putStorage.Products;

            _storagesService.UpdateStorage(storage);

            return Ok(storage);
        }

        #endregion

        #region DELETE METHODS

        [HttpDelete("{sid:long}")]
        public IActionResult DeleteStorage(long sid)
        {
            var storage = _storagesService.GetStorage(sid);

            if (storage == null)
                return NotFound();

            _storagesService.DeleteStorage(storage);

            return Ok();
        }

        #endregion
    }
}
