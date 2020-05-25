namespace Altkom.CSharp.Models
{
    public abstract class Item : Base
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
