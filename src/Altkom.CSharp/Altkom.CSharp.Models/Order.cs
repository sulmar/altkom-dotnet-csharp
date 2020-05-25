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
        public DateTime? ShipDate { get; set; }

        public Order()
        {
            this.OrderDate = DateTime.Now;
            this.Status = OrderStatus.Draft;
        }

        public Order(string orderNumber, Customer customer)
            : this()
        {
            this.OrderNumber = orderNumber;
            this.Customer = customer;
        }

    }
}
