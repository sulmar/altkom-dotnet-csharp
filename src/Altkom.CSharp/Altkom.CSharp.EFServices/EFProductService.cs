using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using Altkom.CSharp.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

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
            var entities = context.ChangeTracker.Entries();

            context.Entry(entity).State = EntityState.Unchanged;

            Debug.WriteLine(context.Entry(entity).State);

            context.Items.Add(entity);

            Debug.WriteLine(context.Entry(entity).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(entity).State);

            entity.Color = "purple";

            Debug.WriteLine(context.Entry(entity).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(entity).State);


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
                .OrderBy(p => p.Name)
                .ToList();
        }

        public IEnumerable<Product> Get(ProductSearchCriteria searchCriteria)
        {
            IQueryable<Product> query = products.AsQueryable();

            if (searchCriteria.FromUnitPrice.HasValue)
            {
                query = query.Where(p => p.UnitPrice >= searchCriteria.FromUnitPrice);
            }

            if (searchCriteria.ToUnitPrice.HasValue)
            {
                query = query.Where(p => p.UnitPrice <= searchCriteria.ToUnitPrice);
            }

            if (searchCriteria.FromWeight.HasValue)
            {
                query = query.Where(p => p.Weight >= searchCriteria.FromWeight);
            }

            if (searchCriteria.ToWeight.HasValue)
            {
                query = query.Where(p => p.Weight <= searchCriteria.ToWeight);
            }

            if (!string.IsNullOrEmpty(searchCriteria.Color))
            {
                query = query.Where(p => p.Color == searchCriteria.Color);
            }

            return query.ToList();

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
