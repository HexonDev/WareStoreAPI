using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WareStoreAPI.Models
{
    public class Storage
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
