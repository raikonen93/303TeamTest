using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _303TeamTest.Models
{
    public class DetailsFormModel
    {
        public long CustomerId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public bool Active { get; set; }
    }
}