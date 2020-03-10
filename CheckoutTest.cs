using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTest
{
    [TestClass]
    public class CheckoutTest
    {
        private ICheckout checkout;

        public CheckoutTest()
        {
            IEnumerable<Item> items = new[]
            {
                new Item{SKU = 'A99', Price = 0.50},
                new Item{SKU = 'B15', Price = 0.30},
                new Item{SKU = 'C40', Price = 0.60}
                
            };

            IEnumerable<Discount> discounts = new[]
            {
                new Discount{SKU = 'A99', Quantity = 3, Value = 1.30},
                new Discount{SKU = 'B15', Quantity = 2, Value = 0.45}
            };

            checkout = new Checkout(items, discounts);
        }

        [Theory]
        [InlineData("A99", 0.50)]
        [InlineData("B15", 0.30)]
        [InlineData("C40", 0.60)]        
        public void ScanCheckout(string item, int output)
        {
            Assert.Equal(output, checkout.Scan(item).Total());
        }
    }
}
