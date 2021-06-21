using System.Collections.Generic;

namespace WareStoreAPI.Models
{
    public class Store
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Product> Stock { get; set; }
    }
}
