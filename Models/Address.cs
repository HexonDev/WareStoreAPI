namespace WareStoreAPI.Models
{
    public class Address
    {
        public long Id { get; set; }

#nullable enable
        public string? ShortName { get; set; }
#nullable disable
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string Floor { get; set; }
        public string Door { get; set; }
    }
}
