using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
    public class StoresController : ControllerBase
    {
        private readonly StoresService _storesService;

        public StoresController(StoresService storesService, IFileProvider fileProvider)
        {
            this._storesService = storesService;
        }

        #region GET METHODS

        [HttpGet]
        public IActionResult GetStores()
        {
            return Ok(_storesService.GetStores());
        }

        [HttpGet("{sid:long}")]
        public IActionResult GetStore(long sid)
        {
            var store = _storesService.GetStore(sid);

            if (store == null)
                return NotFound();

            return Ok(store);
        }

        [HttpGet("{sid:long}/products")]
        public IActionResult GetStoreProducts(long sid)
        {
            var store = _storesService.GetStore(sid);

            if (store == null)
                return NotFound();

            return Ok(store.Stock.ToArray());
        }

        #endregion

        #region POST METHODS

        [HttpPost]
        public IActionResult PostStore(Store store)
        {
            if (store == null)
                return BadRequest();

            _storesService.AddStore(store);

            return Ok(store);
        }


        [HttpPost("{sid:long}/products")]
        public IActionResult PostStoreProduct(long sid, Product product)
        {
            var store = _storesService.GetStore(sid);
            
            if (store == null)
                return NotFound();

            if (product == null)
                return BadRequest();

            _storesService.AddStoreProduct(store, product);

            return Ok(product);
        }

        #endregion

        #region PUT/PATCH METHODS

        [HttpPatch("{sid:long}")]
        public IActionResult PatchStore(long sid, JsonPatchDocument<Store> patchStore)
        {
            if (patchStore == null)
                return BadRequest();

            var store = _storesService.GetStore(sid);

            if (store == null)
                return NotFound();

            patchStore.ApplyTo(store, ModelState);
            _storesService.UpdateStore(store);

            return Ok(store);
        }

        [HttpPut("{sid:long}")]
        public IActionResult PutStore(long sid, Store putStore)
        {
            if (putStore == null)
                return BadRequest("Model is null");

            var store = _storesService.GetStore(sid);

            if (store == null)
                return NotFound();


            store.Address = putStore.Address;
            store.AddressId = putStore.Address.Id;
            store.Name = putStore.Name;
            store.Stock = putStore.Stock;

            _storesService.UpdateStore(store);

            return Ok(store);
        }

        #endregion

        #region DELETE METHODS

        [HttpDelete("{sid:long}")]
        public IActionResult DeleteStore(long sid)
        {
            var store = _storesService.GetStore(sid);

            if (store == null)
                return NotFound();

            _storesService.DeleteStore(store);

            return Ok();
        }

        #endregion
    }
}
