using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WareStoreAPI.Models;
using WareStoreAPI.Repositories;

namespace WareStoreAPI.Services
{
    public class ProductsService
    {
        private readonly IRepository _repository;

        public ProductsService(IRepository repository)
        {
            this._repository = repository;
        }

        public ICollection<Product> GetProducts()
        {
            return _repository.SelectAll<Product>();
        }

        public Product GetProduct(long id)
        {
            return _repository.SelectById<Product>(id);
        }

        public void AddProduct(Product product)
        {
            _repository.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            var dataArray = product.Data.ToArray();
            for (int i = dataArray.Length - 1; i >= 0; i--)
            {
                _repository.Delete(dataArray[i]);
            }

            _repository.Delete(product);
        }
    }
}
