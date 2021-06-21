using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareStoreAPI.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte PermissionLevel { get; set; }   
    }
}
