using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean Blocked { get; set; }
    }
}