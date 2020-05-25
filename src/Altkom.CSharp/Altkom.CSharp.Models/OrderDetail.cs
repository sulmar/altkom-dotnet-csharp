namespace Altkom.CSharp.Models
{
    public class OrderDetail : Base
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderDetail(int id, Item item, int quantity = 1, decimal? unitPrice = null)
        {
            this.Id = id;            
            this.Quantity = quantity;
            this.UnitPrice = unitPrice ?? item.UnitPrice;
        }
    }
}
