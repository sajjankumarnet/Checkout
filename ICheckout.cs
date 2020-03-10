using System;

namespace Kata
{
    public interface ICheckout
    {
        ICheckout Scan(String scan);        
        string[] ScannedProducts { get; }
        decimal Total();
    }
}
