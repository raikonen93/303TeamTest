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
          
            //if (ent.Customers.FirstOrDefault(t => t.Login == "test") == null)
            //{
            //    Customers newCust = new Customers();
            //    newCust.Login = "test";
            //    newCust.Password = Encryption.Encrypt("Admin");
            //    ent.Customers.Add(newCust);
            //    ent.SaveChanges();
            //}
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("test"), Email= "arzha@gmail.com", PhoneNumber="3312312",FirstName= "Nelson", LastName= "Enrike" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("sveta"), Email = "sveta@gmail.com", PhoneNumber = "565645645", FirstName = "Svetlana", LastName = "Kaliuzhina" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("mil"), Email = "mil@mail.ru", PhoneNumber = "312567786", FirstName = "Milan", LastName = "Baro" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("buf"), Email = "buf@psg.fr", PhoneNumber = "312312377", FirstName = "Kim", LastName = "Carage" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("feli"), Email = "feli@milan.it", PhoneNumber = "787654321", FirstName = "Ciro", LastName = "Imobile" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("bin"), Email = "vinnik@mail.ru", PhoneNumber = "31237879", FirstName = "Oleg", LastName = "Shevchenko" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("Avorro"), Email = "vorona@mail.ru", PhoneNumber = "12233344", FirstName = "Jack", LastName = "Sparrow" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("lui"), Email = "lui@mail.ru", PhoneNumber = "455568787", FirstName = "Olya", LastName = "Polyakova" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("fran"), Email = "frank@mail.ru", PhoneNumber = "678787785", FirstName = "Harry", LastName = "Potter" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("jerome"), Email = "jerome@gmail.com", PhoneNumber = "3218827", FirstName = "Drako", LastName = "Malfoy" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("phil"), Email = "phil@gmail.com", PhoneNumber = "889865453", FirstName = "Arjen", LastName = "Robben" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("basty"), Email = "basty@gmail.com", PhoneNumber = "332348995", FirstName = "Xavi", LastName = "Martinez" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("mario"), Email = "mario@gmail.com", PhoneNumber = "1457785785", FirstName = "Jerome", LastName = "Boateng" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("mich"), Email = "mich@gmail.com", PhoneNumber = "5575858675", FirstName = "Philip ", LastName = "Lahm" });
            //ent.Customers.Add(new Customers { Login = "", Password = Encryption.Encrypt("drako"), Email = "drako@slizerin.ru", PhoneNumber = "32378898958", FirstName = "Mario", LastName = "Gomez" });





            ent.SaveChanges();
        }
    }
}
