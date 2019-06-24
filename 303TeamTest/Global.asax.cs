using _303TeamTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using _303TeamTest.Helpers;

namespace _303TeamTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            TestDatabaseEntities ent = new TestDatabaseEntities();
            //if (ent.Customers.FirstOrDefault(t => t.Login == "Admin") == null)
            //{
            //    Customers newCust = new Customers();
            //    newCust.Login = "Admin";
            //    newCust.Password = Encryption.Encrypt("Admin");
            //    ent.Customers.Add(newCust);
            //    ent.SaveChanges();
            //}
        }
    }
}
