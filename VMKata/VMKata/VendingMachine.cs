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
            Inventory = new ProductCollection();
        }
        #endregion

        #region Properties
        public CoinCollection CoinSlot { get; private set; }
        public CoinCollection CoinReturn { get; private set; }
        public ProductCollection Inventory { get; private set; }
        public string Display 
        { 
            get
            {
                string display;

                if (!string.IsNullOrEmpty(TemporaryDisplay))
                {
                    display = TemporaryDisplay;
                }
                else if(CoinSlot.Value == 0)
                {
                    display = "INSERT COINS";
                }
                else
                    return string.Format("{0:C}", CoinSlot.Value / 100.0);

                return display;
            }
        }

        // Placeholder for an explicit status string that has
        // to be displayed.
        private string TemporaryDisplay { get; set; }


        #endregion

        #region Methods
        public void Insert(Coin coin, int num)
        {
            if (coin == Coin.Penny)
                CoinReturn.Insert(coin, num);
            else
                CoinSlot.Insert(coin, num);
        }

        public void Insert(Product product, int num)
        {
            Inventory.Insert(product, num);
        }

        public void Dispense(Product product)
        {
            int price = GetPrice(product);
            if(CoinSlot.Value >= price)
            {
                Inventory.Dispense(product);
                TemporaryDisplay = "THANK YOU";
            }
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
            else if(product == Product.Candy)
            {
                price = 65;
            }

            return price;
        }
        #endregion
    }
}
