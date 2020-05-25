using System;
using System.Collections.Generic;

namespace Altkom.CSharp.Models
{

    public class Order : Base
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
