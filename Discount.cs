using System;

namespace Kata
{
    public class Discount : IDiscount
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal OfferPrice { get; set; }
    }
}
