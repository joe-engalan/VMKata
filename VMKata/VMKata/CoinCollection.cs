using System;
using System.Collections.Generic;

namespace VMKata
{
    public class CoinCollection
    {
        #region Constructor
        public CoinCollection()
        {
            Coins = new Dictionary<Coin, int>();
        }
        #endregion

        #region Properties
        public int Value
        {
            get
            {
                return
                    Count(Coin.Quarter) * CoinValue(Coin.Quarter) +
                    Count(Coin.Dime) * CoinValue(Coin.Dime) +
                    Count(Coin.Nickel) * CoinValue(Coin.Nickel) +
                    Count(Coin.Penny) * CoinValue(Coin.Penny);
            }
        }

        private Dictionary<Coin, int> Coins { get; set; }

        #endregion

        #region Methods
        // Insert a number of one type of coin into the collection
        internal void Insert(Coin coin, int num)
        {
            if(Coins.ContainsKey(coin))
            {
                Coins[coin] += num;
            }
            else
            {
                Coins.Add(coin, num);
            }
        }

        private void Remove(Coin coin, int num)
        {
            if(Coins.ContainsKey(coin))
            {
                Coins[coin] -= num;
            }
        }

        internal void EmptyInto(CoinCollection collection)
        {
            foreach(var kvp in Coins)
            {
                collection.Insert(kvp.Key, kvp.Value);
            }
            Coins.Clear();
        }

        internal void DispenseInto(CoinCollection collection, int amount)
        {
            // Use a cascading subtraction system, like you're taught in 
            // retail for counting change.
            int numQuartersDispensed = DispenseCoinInto(collection, Coin.Quarter, amount);
            amount -= numQuartersDispensed * CoinValue(Coin.Quarter);

            int numDimesDispensed = DispenseCoinInto(collection, Coin.Dime, amount);
            amount -= numDimesDispensed * CoinValue(Coin.Dime);

            int numNickelsDispensed = DispenseCoinInto(collection, Coin.Nickel, amount);
            amount -= numNickelsDispensed * CoinValue(Coin.Nickel);

            int numPenniesDispensed = DispenseCoinInto(collection, Coin.Penny, amount);
            amount -= numPenniesDispensed * CoinValue(Coin.Penny);
        }

        public int Count(Coin coin)
        {
            int count = 0;
            if(Coins.ContainsKey(coin))
            {
                count = Coins[coin];
            }

            return count;
        }

        #endregion

        #region Utility
        private int CoinValue(Coin coin)
        {
            int value = 0;

            if (coin == Coin.Quarter)
            {
                value = 25;
            }
            else if (coin == Coin.Dime)
            {
                value = 10;
            }
            else if (coin == Coin.Nickel)
            {
                value = 5;
            }
            else if (coin == Coin.Penny)
            {
                value = 1;
            }

            return value;
        }

        private int DispenseCoinInto(CoinCollection collection, Coin coin, int amount)
        {
            int numDispensed = Math.Min(amount / CoinValue(coin), Count(coin));
            collection.Insert(coin, numDispensed);
            Remove(coin, numDispensed);

            return numDispensed;
        }

        #endregion
    }
}
