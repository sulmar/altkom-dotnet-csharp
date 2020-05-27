using Altkom.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.CSharp.EFServices.Configurations
{
    // EF Core
    //public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    //{
    //    public Configure(EntityTypeBuilder builder)
    //    {
    //        builder.Property(p => p.FirstName)
    //           .HasMaxLength(50)
    //           .IsRequired();

    //        builder.Property(p => p.LastName)
    //            .HasMaxLength(50)
    //            .IsRequired();

    //    }
    //}

    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            // HasKey(p => p.Id);

            // Fluent API

            Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
