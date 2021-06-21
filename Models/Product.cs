using System.Collections.Generic;

namespace WareStoreAPI.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public virtual ICollection<ProductData> Data { get; set; }
        public string Barcode { get; set; }
    }
}
