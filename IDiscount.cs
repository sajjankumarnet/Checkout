using System;

namespace Kata
{
    public interface IDiscount
    {
        string SKU { get; set; }
        int Quantity { get; set; }
        decimal OfferPrice { get; set; }
    }
}
