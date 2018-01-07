using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachineATMAutomation.Logic
{

    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set; }



        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void ReturnsMoney()
        {
            // MoneyInTransaction = 0;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;

            // MoneyInTransaction = 0;

        }


    }
}
