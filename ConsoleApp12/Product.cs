using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ConsoleApp12
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
      public double Stock { get; set; }
        public override string ToString()
        {
            return $"{Name}-${Price}(Stock{Stock})";

        }
    }
}
