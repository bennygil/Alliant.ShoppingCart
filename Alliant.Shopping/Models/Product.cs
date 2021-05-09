using System;
using System.Collections.Generic;
using System.Text;

namespace Alliant.Shopping.Models
{
    public class Product
    {
        public string Code { get; set; }        
        public decimal Cost { get; private set; }
        public int DiscountVolume { get; private set; }
        public decimal AdjustedAmount { get; private set; }

        public Product(string code)
        {
            Code = code;
            GetCosts();
        }

        private void GetCosts()
        {
            switch(Code)
            {
                case "A":
                    {
                        Cost = 2.00M;
                        DiscountVolume = 4;
                        AdjustedAmount = 7.00M;
                        break;
                    }
                case "B" :
                    {
                        Cost = 12.00M;
                        DiscountVolume = 0;
                        break;
                    }
                case "C": 
                    {
                        Cost = 1.25M;
                        DiscountVolume = 6;
                        AdjustedAmount = 6.00M;
                        break;
                    }
                case "D":
                    {
                         Cost = 0.15M;
                        DiscountVolume = 0;
                        break;
                    }
                default: break;
            }
        }
    }
}
