using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CSharp.Models.SearchCriterias
{
    public class ProductSearchCriteria
    {
        public decimal FromUnitPrice { get; set; }
        public decimal ToUnitPrice { get; set; }
        public string Color { get; set; }
        public float FromWeight { get; set; }
        public float ToWeight { get; set; }
    }

    
}
