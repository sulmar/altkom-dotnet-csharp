using Altkom.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.CSharp.EFServices
{
    // PMC> Install-Package EntityFramework
    public class MyContext : DbContext
    {
        public MyContext()
            : base("MyConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
