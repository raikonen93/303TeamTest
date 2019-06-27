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
        private const int pageSize = 3;
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

        public ActionResult CustomerRoles()
        {
            return View("~/Views/Home/Partials/CustomerRoles.cshtml");
        }

        public ActionResult CustomersPart()
        {
            TestDatabaseEntities ent = new TestDatabaseEntities();
            var table = ent.Customers.ToList();             
            int pagecount = table.Count / pageSize == 0 ? table.Count / pageSize : table.Count / pageSize + 1;
            ViewBag.PageCount = pagecount;
            return View("~/Views/Home/Partials/CustomersPart.cshtml", table );
        }

        public ActionResult CustomersTable()
        {
            TestDatabaseEntities ent = new TestDatabaseEntities();
            IEnumerable<Customers> table = ent.Customers.Take(pageSize).ToList();
            return View("~/Views/Home/Partials/CustomersTable.cshtml",table);
        }

        public ActionResult CustomerDetails()
        {
            TestDatabaseEntities ent = new TestDatabaseEntities();
            return View("~/Views/Home/Partials/CustomerDetails.cshtml", new DetailsFormModel());
        }
    }
}