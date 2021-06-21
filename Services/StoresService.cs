using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WareStoreAPI.Models;
using WareStoreAPI.Repositories;

namespace WareStoreAPI.Services
{
    public class StoresService
    {
        private readonly IRepository _repository;

        public StoresService(IRepository repository)
        {
            this._repository = repository;
        }

        public ICollection<Store> GetStores()
        {
            return _repository.SelectAll<Store>();
        }

        public Store GetStore(long id)
        {
            return _repository.SelectById<Store>(id);
        }

        public void AddStore(Store store)
        {
            _repository.Create(store);
        }

        public void AddStoreProduct(Store store, Product product)
        {
            store.Stock.Add(product);
            _repository.Update(store);
        }

        public void UpdateStore(Store store)
        {
            _repository.Update(store);
        }

        public void DeleteStore(Store store)
        {
            var productArray = store.Stock.ToArray();

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

            _repository.Delete(store);
            //_repository.Delete(store.Address);
        }
    }
}
