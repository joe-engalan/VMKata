using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMKata
{
    class VendingMachine
    {
        #region Constructor
        public VendingMachine()
        {
            CoinSlot = new CoinCollection();
        }
        #endregion

        #region Properties
        public CoinCollection CoinSlot { get; private set; }

        #endregion
    }
}
