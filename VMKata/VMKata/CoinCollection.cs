using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMKata
{
    class CoinCollection
    {
        #region Properties
        public int Value
        {
            get
            {
                return 
                    Quarters * 25 + 
                    Dimes * 10;
            }
        }

        public int Quarters { get; private set; }
        public int Dimes { get; private set; }

        #endregion

        #region Methods
        // Insert a number of one type of coin into the collection
        public void Insert(Coin coin, int num)
        {
            if (coin == Coin.Quarter)
                Quarters += num;
            else if (coin == Coin.Dime)
                Dimes += num;
        }

        #endregion
    }
}
