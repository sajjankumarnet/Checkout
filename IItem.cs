using System;

namespace Kata
{
    public interface IItem
    {
        string SKU { get; set; }
        decimal UnitPrice { get; set; }
    }
}
