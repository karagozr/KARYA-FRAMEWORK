using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.API.REST.Models.Auth
{
    public class UserModel
    {
        public int UserGroupId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string EMail { get; set; }

        public string Description { get; set; }
    }
}
