using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using Altkom.CSharp.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Altkom.CSharp.EFServices
{
    public class EFProductService : IProductService
    {
        private readonly MyContext context;


        public EFProductService(MyContext context)
        {
            this.context = context;
        }

        public void Add(Product entity)
        {
            context.Items.Add(entity);
            context.SaveChanges();
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            context.Items.AddRange(entities);
            context.SaveChanges();
        }

        private IQueryable<Product> products => context.Items.OfType<Product>();

        public int Count()
        {
            return products.Count();
        }

        public IEnumerable<Product> Get(string color)
        {
            return products
                .Where(p => p.Color == color)
                .OrderBy(p=>p.Name)
                .ToList();
        }

        public IEnumerable<Product> Get(ProductSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            return products.ToList();
        }

        public Product Get(int id)
        {
            return products.SingleOrDefault(product => product.Id == id);
        }

        public void Remove(int id)
        {
            context.Items.Remove(Get(id));
            context.SaveChanges();
        }

        public void Update(Product entity)
        {
            context.SaveChanges();
        }
    }
}
