using Altkom.CSharp.EFServices;
using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Altkom.CSharp.SOAPService
{
    /// <summary>
    /// Summary description for MyService
    /// </summary>
    [WebService(Namespace = "http://www.altkom.pl/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod]
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            return customers;
        }

        [WebMethod]
        public List<Product> GetProducts()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyEFDb;Integrated Security=True;Application Name=Altkom";
            MyContext context = new MyContext(connectionString);

            IProductService productService = new EFProductService(context);

            var products = productService.Get();

            return products.ToList();
        }

        [WebMethod]
        public List<Product> GetProductsByColor(string color)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyEFDb;Integrated Security=True;Application Name=Altkom";
            MyContext context = new MyContext(connectionString);

            IProductService productService = new EFProductService(context);

            var products = productService.Get(color);

            return products.ToList();
        }
    }
}
