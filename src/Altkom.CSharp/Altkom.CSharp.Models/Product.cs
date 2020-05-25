using System;

namespace Altkom.CSharp.Models
{
    public class Product : Item, ICloneable
    {
        public string Color { get; set; }
        public float Weight { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone(); // płyta kopia

            //Product product = new Product
            //{
            //    Color = this.Color,
            //};

            //return product;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Color}";
        }


    }


}
