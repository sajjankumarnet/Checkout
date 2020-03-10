using System;

namespace Kata
{
    public class Item : IItem
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
