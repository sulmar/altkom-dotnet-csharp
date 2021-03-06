﻿using System;

namespace Altkom.CSharp.Models
{
    public class Service : Item
    {
        public TimeSpan Duration { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {Duration}";
        }
    }
}
