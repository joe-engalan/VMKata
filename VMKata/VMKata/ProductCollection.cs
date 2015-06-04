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
        public int Colas { get; private set; }
        public int Candies { get; private set; }
        public int Chips { get; private set; }
        #endregion

        #region Methods
        internal void Insert(Product product, int num)
        {
            if (product == Product.Cola)
                Colas += num;
        }

        internal void Dispense(Product product)
        {
            if (product == Product.Cola)
                Colas--;
        }
        #endregion
    }
}
