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
        public string Display 
        { 
            get
            {
                if(CoinSlot.Value == 0)
                    return "INSERT COINS";
                else
                    return string.Format("{0:C}", CoinSlot.Value / 100.0);
            }
        }

        #endregion

        #region Methods
        public void Insert(Coin coin, int num)
        {
            if (coin == Coin.Penny)
                CoinReturn.Insert(coin, num);
            else
                CoinSlot.Insert(coin, num);
        }

        public int GetPrice(Product product)
        {
            int price = 0;
            if (product == Product.Cola)
            {
                price = 100;
            }
            else if(product == Product.Chips)
            {
                price = 50;
            }

            return price;
        }
        #endregion
    }
}
