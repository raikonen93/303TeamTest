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
        private const int pageSize = 2;
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
                var encryptedPassword = StringCipher.Encrypt(data.Password);
                var customer = ent.Customers.FirstOrDefault(t => (t.Login.ToUpper() == data.Login && t.Password == encryptedPassword));
                var roles=ent.CustomerRoles.Where(t=>(t.Customers.Login.ToUpper() == data.Login && t.Customers.Password == encryptedPassword && t.Role.Name!="Customer"));
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
            if (Request.Cookies["searchtext"] != null)
            {
                var c = new HttpCookie("searchtext");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
               
            return View();
        }

        public ActionResult CustomerRoles()
        {
            return View("~/Views/Home/Partials/CustomerRoles.cshtml");
        }

        public ActionResult CustomersPart(int? page, string columnId, string src)
        {
            ViewBag.SelectedPage = page==null?1:page;            
            ViewBag.SortedColumn = columnId;
            ViewBag.SortedType = src;
            string searchtext = string.Empty;
            if (Request.Cookies["searchtext"]!=null)
                searchtext=Request.Cookies["searchtext"].Value;

            int skipCount = (ViewBag.SelectedPage - 1) * pageSize;
            TestDatabaseEntities ent = new TestDatabaseEntities();
            List<Customers> table;
            int tablecount = 0;
            if (columnId == "loginSort")
            {
                if (src.Contains("asc"))
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderBy(t => t.Login).Skip(skipCount).Take(pageSize).ToList();
                }
                else
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderBy(t => t.Login).Skip(skipCount).Take(pageSize).ToList();
                }
             }
            else if (columnId == "nameSort")
            {
                if (src.Contains("asc"))
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderBy(t => t.FirstName).ThenBy(t => t.LastName).Skip(skipCount).Take(pageSize).ToList();
                }
                else
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderByDescending(t => t.FirstName).ThenBy(t => t.LastName).Skip(skipCount).Take(pageSize).ToList();
                }
            }
            else if (columnId == "emailSort")
            {
                if (src.Contains("asc"))
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderBy(t => t.Email).Skip(skipCount).Take(pageSize).ToList();
                }
                else
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderByDescending(t => t.Email).Skip(skipCount).Take(pageSize).ToList();
                }
                
            }
            else if (columnId == "phoneSort")
            {
                if (src.Contains("asc"))
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderBy(t => t.PhoneNumber).Skip(skipCount).Take(pageSize).ToList();
                }
                else
                {
                    var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                    tablecount = select.Count;
                    table = select.OrderByDescending(t => t.PhoneNumber).Skip(skipCount).Take(pageSize).ToList();
                }
            }
            else
            {
                var select = ent.Customers.Where(t => t.Email.Contains(searchtext) || t.FirstName.Contains(searchtext) || t.LastName.Contains(searchtext) || t.Login.Contains(searchtext) || t.PhoneNumber.Contains(searchtext) || t.CustomerRoles.Any(r => r.Role.Name.Contains(searchtext))).ToList();
                tablecount = select.Count;
                table = select.OrderBy(t => t.CustomerId).Skip(skipCount).Take(pageSize).ToList(); 
            } 

            int pagecount = tablecount % pageSize == 0 ? tablecount / pageSize : tablecount / pageSize + 1;
            ViewBag.PageCount = pagecount;
            ViewBag.TotalRowsCount = tablecount;
            ViewBag.SearchText = searchtext;

            return View("~/Views/Home/Partials/CustomersPart.cshtml", table );
        }       

        public ActionResult CustomerDetails()
        {
            TestDatabaseEntities ent = new TestDatabaseEntities();
            return View("~/Views/Home/Partials/CustomerDetails.cshtml", new DetailsFormModel());
        }

        public ActionResult PageChangedOrSorted(int pagenumber, string sortedColumn)
        {
            ViewBag.SelectedPage = 1;
            TestDatabaseEntities ent = new TestDatabaseEntities();
            IEnumerable<Customers> table = ent.Customers.Take(pageSize).ToList();
            return View("~/Views/Home/Partials/CustomersTable.cshtml", table);
        }

        public ActionResult EditOrNewCustomer(string customerId="")
        {
            TestDatabaseEntities ent = new TestDatabaseEntities();
            DetailsFormModel editCustomer = new DetailsFormModel();
            var customer = ent.Customers.Where(t => t.CustomerId.ToString() == customerId).FirstOrDefault();
            if (customer != null)
            {
                editCustomer.CustomerId = customer.CustomerId;
                editCustomer.Login = customer.Login;
                editCustomer.Password = StringCipher.Decrypt(customer.Password); 
                editCustomer.ConfirmPassword = StringCipher.Decrypt(customer.Password); 
                editCustomer.FirstName = customer.FirstName;
                editCustomer.LastName = customer.LastName;
                editCustomer.Email = customer.Email;
                if (customer.CustomerDetailsData != null)
                {
                    editCustomer.ChangerName = customer.CustomerDetailsData.ChangerName;
                    editCustomer.ChangedDate = customer.CustomerDetailsData.ChangedDate;
                    editCustomer.CreatedDate = customer.CustomerDetailsData.CreatedDate;
                    editCustomer.CreatorName = customer.CustomerDetailsData.CreatorName;

                }
            }
            return View("~/Views/Home/Partials/CustomerDetails.cshtml", editCustomer);
        }

        public void SaveCustomersDetail()
        {
            RedirectToAction("Customers");
        }

        public void CancelEditCustomerDetails()
        {
            RedirectToAction("Customers");
        }

        public void DeleteCustomer(int? page, string columnId, string src, string customerId)
        {
            //делаем удаление, сохранение и редирект на метод CustomersPart
        }
    }
}