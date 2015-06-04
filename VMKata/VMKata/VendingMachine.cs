
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

        // The coin slot is where people put in money
        public CoinCollection CoinSlot { get; private set; }

        // The coin return is where change is dispensed and coins
        // are returned upon request.
        public CoinCollection CoinReturn { get; private set; }

        // The coin bank reresents the coins this machine has collected
        // The bank is used to dispense change.
        public CoinCollection CoinBank { get; private set; }

        // The inventory represents the products this machine has 
        // on hand that can be dispensed.
        public ProductCollection Inventory { get; private set; }

        // The display shows status messages as well as the
        // the current amount of money in the coin slot.
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
                        // Let the use know if there's
                        // no money left to make change.
                        display = "EXACT CHANGE ONLY";
                    }
                    else
                    {
                        // If the coin slot is empty
                        // instruct the user to add money.
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

        // Insert coins into the coin slot.
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

        // Add products to the invenory
        public void Insert(Product product, int num)
        {
            Inventory.Insert(product, num);
        }

        // Add money he the coin bank. 
        public void AddToBank(Coin coin, int num)
        {
            CoinBank.Insert(coin, num);
        }

        // Dispense available products. 
        // Change is also calculated and placed
        // in the coin return as part of the transaction.
        public void Dispense(Product product)
        {
            int price = GetPrice(product);

            if(Inventory.Count(product) == 0)
            {
                // The item requsted is out of stock.
                TemporaryDisplay = "SOLD OUT";
            }
            else if(CoinSlot.Value >= price)
            {
                // There's enough money and an item
                // to dispense.
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

                // Deposit the money into the coinbank.
                CoinSlot.EmptyInto(CoinBank);
            }
            else
            {
                // If there isn't enough money to pay for an item
                // when they try to dispense, remind the use how much the item costs.
                TemporaryDisplay = "PRICE " + CreateCurrencyString(price);
            }
        }

        // Return all coins back to the user.
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
