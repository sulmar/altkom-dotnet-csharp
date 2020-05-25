namespace Altkom.CSharp.Models
{
    public class OrderDetail : Base
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
