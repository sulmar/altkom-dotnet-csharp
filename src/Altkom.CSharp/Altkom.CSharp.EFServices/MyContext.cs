using Altkom.CSharp.EFServices.Configurations;
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
        public MyContext(string connectionString)
            : base(connectionString)
        {
        }

        public MyContext()
            : base("MyConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());

            // EF Core
            // modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
