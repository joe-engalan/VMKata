using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMKata
{
    public class VendingMachine
    {
        #region Constructor
        public VendingMachine()
        {
            CoinSlot = new CoinCollection();
            CoinReturn = new CoinCollection();
        }
        #endregion

        #region Properties
        public CoinCollection CoinSlot { get; private set; }
        public CoinCollection CoinReturn { get; private set; }

        #endregion

        #region Methods
        public void Insert(Coin coin, int num)
        {
            if (coin == Coin.Penny)
                CoinReturn.Insert(coin, num);
            else
                CoinSlot.Insert(coin, num);
        }
        #endregion
    }
}
