using _303TeamTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _303TeamTest.Helpers;
namespace _303TeamTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginIntoSystem(CustomerLogin data)
        {
            if (ModelState.IsValid)
            {
                TestDatabaseEntities ent = new TestDatabaseEntities();
                var decryptedPassword = Encryption.Encrypt(data.Password);
                var customer = ent.Customers.FirstOrDefault(t => (t.Login.ToUpper() == data.Login && t.Password == decryptedPassword));
                var roles=ent.CustomerRoles.Where(t=>(t.Customers.Login.ToUpper() == data.Login && t.Customers.Password == decryptedPassword && t.Role.Name!="Customer"));
                if (customer == null)
                {
                    ViewBag.ErrorMessage = "Unfortunately the user is not found!";
                    return View("Login");
                }
                else if (customer.IsDisabled==true)
                {
                    ViewBag.ErrorMessage = "Unfortunately the user is locked!";
                    return View("Login");                   
                }
                else if (roles==null)
                {
                    ViewBag.ErrorMessage = "Unfortunately the user is not authorized to enter!";
                    return View("Login");
                }
                else
                return Redirect("/Home/Customers");
            }
            else
            {
                ViewBag.ErrorMessage = "Unfortunately some of the fields are not filled!";
                return View("Login");
            }
        }

        public ActionResult Customers()
        {
            return View();
        }
    }
}