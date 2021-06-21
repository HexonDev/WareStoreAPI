using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareStoreAPI.Models;
using WareStoreAPI.Repositories;

namespace WareStoreAPI.Services
{
    public class AddressesService
    {
        private readonly IRepository _repository;

        public AddressesService(IRepository repository)
        {
            this._repository = repository;
        }

        public ICollection<Address> GetAddresses()
        {
            return _repository.SelectAll<Address>();
        }

        public Address GetAddress(long id)
        {
            return _repository.SelectById<Address>(id);
        }

        public void AddAddress(Address address)
        {
            _repository.Create(address);
        }

        public void UpdateAddress(Address address)
        {
            _repository.Update(address);
        }

        public void DeleteAddress(Address address)
        {
            _repository.Delete(address);
        }
    }
}
