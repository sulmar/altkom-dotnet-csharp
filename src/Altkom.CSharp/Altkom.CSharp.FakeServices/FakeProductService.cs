using Altkom.CSharp.IServices;
using Altkom.CSharp.Models;
using Altkom.CSharp.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.CSharp.FakeServices
{  
    public class FakeProductService : IProductService
    {
        private readonly ICollection<Product> products;

        // private const int count = 100;
        private readonly DateTime startDate = DateTime.Now;

        public FakeProductService()
        {            
            products = new List<Product>();
        }

        public void Add(Product entity)
        {
            products.Add(entity);
        }

        public void AddRange(IEnumerable<Product> entities)
        {            
            foreach (Product product in entities)
            {
                Add(product);
            }
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            return products;
        }

        public Product Get(int id)
        {
            foreach (Product product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }

        public IEnumerable<Product> Get(decimal from, decimal to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(string color)
        {
            ICollection<Product> results = new List<Product>();

            foreach (Product product in products)
            {
                if (product.Color == color)
                {
                    results.Add(product);
                }
            }

            return results;
        }

        public IEnumerable<Product> Get(ProductSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            products.Remove(Get(id));
        }

        public void Update(Product entity)
        {
            Remove(entity.Id);
            Add(entity);
        }
    }
}
