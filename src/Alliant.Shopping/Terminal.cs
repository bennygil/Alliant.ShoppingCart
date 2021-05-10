
using Alliant.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alliant.Shopping
{
    public class Terminal : ITerminal
    {
        private ShoppingCart _shoppingCart = new ShoppingCart();        
        public void Scan(string item)
        {
            this._shoppingCart.Products.Add(new Product(item));
        }

        public decimal Total()
        {
            decimal total = 0.00M;
            var groupedProducts = this._shoppingCart.Products.GroupBy(p => p.Code).ToDictionary(c => c.Key, g => g.ToList());
            
            foreach(var productList in groupedProducts)
            {
                total += DiscountCalculator(productList.Value.ToArray());
            }

            return total;
        }

        private decimal DiscountCalculator(Product[] products)
        {
            int volumeCounter = 0;
            bool volQuantityMet = false;
            decimal total = 0M;
            for (int i = 0; i < products.Length; i++)
            {
                Product product = products[i];
                volumeCounter++;

                if (product.DiscountVolume == 0)
                {
                    total += product.Cost;
                    continue;
                }

                if(volumeCounter == product.DiscountVolume)
                {                    
                    if(volQuantityMet)
                    {
                        total += product.AdjustedAmount;
                    }                    
                    else
                    {
                        total = product.AdjustedAmount;
                        volQuantityMet = true;
                    }
                    volumeCounter = 0;
                }
                else
                {
                    total += product.Cost;
                }
            }
            return total;
        }
    }
}
