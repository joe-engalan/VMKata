
namespace VMKata
{
    public class VendingMachine
    {
        #region Constructor
        public VendingMachine()
        {
            CoinSlot = new CoinCollection();
            CoinReturn = new CoinCollection();
            CoinBank = new CoinCollection();
            Inventory = new ProductCollection();
        }
        #endregion

        #region Properties
        public CoinCollection CoinSlot { get; private set; }
        public CoinCollection CoinReturn { get; private set; }
        public CoinCollection CoinBank { get; private set; }
        public ProductCollection Inventory { get; private set; }
        public string Display 
        { 
            get
            {
                string display;

                if (!string.IsNullOrEmpty(TemporaryDisplay))
                {
                    // The temporary display is only displayed
                    // once. After it has been seen, displays 
                    // revert to their normal behavior.
                    display = TemporaryDisplay;
                    TemporaryDisplay = string.Empty;
                }
                else if(CoinSlot.Value == 0)
                {
                    if(CoinBank.Value == 0)
                    {
                        display = "EXACT CHANGE ONLY";
                    }
                    else
                    {
                        display = "INSERT COINS";
                    }
                }
                else
                {
                    display = CreateCurrencyString(CoinSlot.Value);
                }

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
            {
                CoinReturn.Insert(coin, num);
            }
            else
            {
                CoinSlot.Insert(coin, num);
            }
        }

        public void Insert(Product product, int num)
        {
            Inventory.Insert(product, num);
        }

        public void AddToBank(Coin coin, int num)
        {
            CoinBank.Insert(coin, num);
        }

        public void Dispense(Product product)
        {
            int price = GetPrice(product);

            if(Inventory.Count(product) == 0)
            {
                TemporaryDisplay = "SOLD OUT";
            }
            else if(CoinSlot.Value >= price)
            {
                Inventory.Dispense(product);
                TemporaryDisplay = "THANK YOU";

                int changeDue = CoinSlot.Value - price;
                if(changeDue > 0)
                {
                    // Put the change in the coin return.
                    // Change comes from the coin bank before
                    // the coinslot is dumped into the coin bank.
                    CoinBank.DispenseInto(CoinReturn, changeDue);
                }

                CoinSlot.EmptyInto(CoinBank);
            }
            else
            {
                TemporaryDisplay = "PRICE " + CreateCurrencyString(price);
            }
        }

        public void ReturnCoins()
        {
            CoinSlot.EmptyInto(CoinReturn);
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

        #region Utility
        private string CreateCurrencyString(int amount)
        {
            return string.Format("{0:C}", amount / 100.0);
        }
        #endregion
    }
}
