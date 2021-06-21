using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WareStoreAPI.Models;
using WareStoreAPI.Repositories;

namespace WareStoreAPI.Services
{
    public class StoragesService
    {
        private readonly IRepository _repository;

        public StoragesService(IRepository repository)
        {
            this._repository = repository;
        }


        public ICollection<Storage> GetStorages()
        {
            return _repository.SelectAll<Storage>();
        }

        public Storage GetStorage(long id)
        {
            return _repository.SelectById<Storage>(id);
        }

        public void AddStorage(Storage newStorage)
        {
            _repository.Create(newStorage);
        }

        public void AddStorageProduct(Storage storage, Product product)
        {
            storage.Products.Add(product);
            _repository.Update(storage);
        }

        public void UpdateStorage(Storage storage)
        {
            _repository.Update(storage);
        }

        public void DeleteStorage(Storage storage)
        {
            var productArray = storage.Products.ToArray();

            foreach (var product in productArray)
            {
                var dataArray = product.Data.ToArray();
                for (int i = dataArray.Length - 1; i >= 0; i--)
                {
                    _repository.Delete(dataArray[i]);
                }
            }

            for (int i = productArray.Length - 1; i >= 0; i--)
            {
                _repository.Delete(productArray[i]);
            }



            //_repository.Delete(storage.Address);
            _repository.Delete(storage);
        }
    }
}
