using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _303TeamTest.Models
{
    public class CustomerLogin
    {
        [Required(ErrorMessage = "Login is required!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}