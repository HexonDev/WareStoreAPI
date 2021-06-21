using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareStoreAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte PermissionLevel { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
