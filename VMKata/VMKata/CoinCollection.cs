﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMKata
{
    public class CoinCollection
    {
        #region Properties
        public int Value
        {
            get
            {
                return 
                    Quarters * 25 + 
                    Dimes * 10 +
                    Nickels * 5 +
                    Pennies;
            }
        }

        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickels { get; private set; }
        public int Pennies { get; private set; }

        #endregion

        #region Methods
        // Insert a number of one type of coin into the collection
        internal void Insert(Coin coin, int num)
        {
            if (coin == Coin.Quarter)
                Quarters += num;
            else if (coin == Coin.Dime)
                Dimes += num;
            else if (coin == Coin.Nickel)
                Nickels += num;
            else if (coin == Coin.Penny)
                Pennies += num;
        }

        internal void EmptyInto(CoinCollection collection)
        {
            collection.Quarters += Quarters;
            Quarters = 0;

            collection.Dimes += Dimes;
            Dimes = 0;

            collection.Nickels += Nickels;
            Nickels = 0;

            collection.Pennies += Pennies;
            Pennies = 0;
        }

        internal void DispenseInto(CoinCollection collection, int amount)
        {
            // Use a cascading subtraction system, like you're taught in 
            // retail for counting change.
            while(amount >= 25 && Quarters > 0)
            {
                collection.Quarters++;
                Quarters--;
                amount -= 25;
            }

            while(amount >= 10 && Dimes > 0)
            {
                collection.Dimes++;
                Dimes--;
                amount -= 10;
            }

            while(amount >= 5 && Nickels > 0)
            {
                collection.Nickels++;
                Nickels--;
                amount -= 5;
            }

            while(amount >= 1 && Pennies > 0)
            {
                collection.Pennies++;
                Pennies--;
                amount -= 1;
            }
        }
        #endregion
    }
}
