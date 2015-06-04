using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMKata
{
    public class ProductCollection
    {
        #region Properties
        private Dictionary<Product, int> Products { get; set; }
        #endregion

        #region Constructor
        public ProductCollection()
        {
            Products = new Dictionary<Product, int>();
        }
        #endregion

        #region Methods
        internal void Insert(Product product, int num)
        {
            if(Products.ContainsKey(product))
            {
                Products[product] += num;
            }
            else
            {
                Products.Add(product, num);
            }
        }

        internal void Dispense(Product product)
        {
            int count = Count(product);
            if(count > 0)
            {
                Products[product] = count - 1;
            }
        }

        public int Count(Product product)
        {
            int count = 0;
            if(Products.ContainsKey(product))
            {
                count = Products[product];
            }

            return count;
        }
        #endregion
    }
}
