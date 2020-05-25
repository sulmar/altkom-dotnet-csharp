using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CSharp.Models
{
    // int, decimal, datetime, struct

    public struct Location  // -> typ wartosciowy
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }

    public class Address   // -> typ referencyjny
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
    }
}
