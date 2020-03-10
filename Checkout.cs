using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Checkout :ICheckout
    {
        private readonly IEnumerable<IItem> items;
        private readonly IEnumerable<IDiscount> discounts;
        public string[] ScannedProducts { get; private set; }

        public Checkout(IEnumerable<IItem> items, IEnumerable<IDiscount> discounts)
        {
            this.items = items;
            this.discounts = discounts;
            ScannedProducts = new string[] { };
        }

        #region functions
        public ICheckout Scan(String scan)
        {
            if (!String.IsNullOrEmpty(scan))
            {
                ScannedProducts = scan
                   .ToCharArray()
                   .Where(scannedSKU => items.Any(item => item.SKU == scannedSKU))
                   .ToArray();
            }
            return this;
        }
    
        /// <summary>
		/// get the total of the checkout
		/// </summary>
        public decimal Total()
        {
            decimal total = 0;
            decimal totalDiscount = 0;
            total = ScannedProducts.Sum(item => PriceForItem(item));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, ScannedProducts));
            return total - totalDiscount;
        }

        private decimal PriceForItem(string sku)
        {
            return items.Single(p => p.SKU == sku).UnitPrice;
        }

        private decimal CalculateDiscount(IDiscount discount, string[] cart)
        {
            int itemCount = cart.Count(item => item == discount.SKU);
            return (itemCount / discount.Quantity) * discount.OfferPrice;
        }

        #endregion
    }
}
