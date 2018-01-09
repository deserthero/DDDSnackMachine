using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachineATMAutomation.Logic
{

    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; } = Money.None;
        public Money MoneyInTransaction { get; private set; } = Money.None;

        public SnackMachine()
        {
        }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
           {
                Money.Cent, Money.TenCent, Money.QuarterCent, Money.Dollar, Money.FiveDollar, Money.TweentyDollar
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();


            MoneyInTransaction += money;
        }

        public void ReturnsMoney()
        {
            // This like MoneyInTransaction = 0 cause the Money class is immutable
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;

            MoneyInTransaction = Money.None;

        }


    }
}
