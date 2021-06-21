using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareStoreAPI.DTO
{
    public class UpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte PermissionLevel { get; set; }
        public string Password { get; set; }
    }
}
