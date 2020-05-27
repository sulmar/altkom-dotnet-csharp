using Altkom.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.CSharp.EFServices.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name)
               .HasMaxLength(100)
               .IsRequired();

            Property(p => p.BarCode)
                .HasMaxLength(13)
                .IsUnicode(false);

            Property(p => p.Color)
                .HasMaxLength(50);
        }
    }
}
