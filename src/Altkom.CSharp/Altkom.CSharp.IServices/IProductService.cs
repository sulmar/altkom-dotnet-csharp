using Altkom.CSharp.Models;
using Altkom.CSharp.Models.SearchCriterias;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.CSharp.IServices
{

    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> Get(string color);

        // IEnumerable<Product> Get(decimal from, decimal to, string color, float weight);
        IEnumerable<Product> Get(ProductSearchCriteria searchCriteria);

        int Count();
    }

}
