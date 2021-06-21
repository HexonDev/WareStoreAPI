using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class AddressesController : ControllerBase
    {
        private readonly AddressesService _addressesService;

        public AddressesController(AddressesService addressesService, IFileProvider fileProvider)
        {
            _addressesService = addressesService;
        }

        #region GET METHODS

        [HttpGet]
        public IActionResult GetAddresses()
        {
            return Ok(_addressesService.GetAddresses());
        }

        [HttpGet("{id:long}")]
        public IActionResult GetAddress(long id)
        {
            var address = _addressesService.GetAddress(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }

        #endregion

        #region POST METHODS

        [HttpPost]
        public IActionResult PostAddress(Address address)
        {
            if (address == null)
                return BadRequest();

            _addressesService.AddAddress(address);

            return Ok(address);
        }

        #endregion

        #region PUT/PATCH METHODS

        [HttpPatch("{id:long}")]
        public IActionResult PatchAddress(long id, JsonPatchDocument<Address> patchAddress)
        {
            var address = _addressesService.GetAddress(id);

            if (address == null)
                return BadRequest();

            patchAddress.ApplyTo(address, ModelState);
            _addressesService.UpdateAddress(address);

            return Ok(address);
        }

        [HttpPut("{sid:long}")]
        public IActionResult PutAddress(long sid, Address putAddress)
        {
            if (putAddress == null)
                return BadRequest("Model is null");

            var address = _addressesService.GetAddress(sid);

            if (address == null)
                return NotFound();


            address.ShortName = putAddress.ShortName;
            address.Country = putAddress.Country;
            address.ZipCode = putAddress.ZipCode;
            address.City = putAddress.City;
            address.Name = putAddress.Name;
            address.Type = putAddress.Type;
            address.Number = putAddress.Number;
            address.Floor = putAddress.Floor;
            address.Door = putAddress.Door;

            _addressesService.UpdateAddress(address);

            return Ok(address);
        }

        #endregion

        #region DELETE METHODS

        [HttpDelete("{id:long}")]
        public IActionResult DeleteAddress(long id)
        {
            var address = _addressesService.GetAddress(id);

            if (address == null)
                return BadRequest();

            _addressesService.DeleteAddress(address);
            
            return Ok();
        }

        #endregion
    }
}
