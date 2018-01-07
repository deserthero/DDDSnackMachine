using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachineATMAutomation.Logic
{
    public sealed class Money
    {
        public int OneCentCount { get; set; }
        public int TenCentCount { get; set; }
        public int QuarterCentCount { get; set; }
        public int OneDollarCount { get; set; }
        public int FiveDollarCount { get; set; }
        public int TweentyDollarCount { get; set; }

        public Money(int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int tweentyDollarCount)
        {
            OneCentCount += oneCentCount;
            TenCentCount += tenCentCount;
            QuarterCentCount += quarterCentCount;
            OneDollarCount += oneDollarCount;
            FiveDollarCount += fiveDollarCount;
            TweentyDollarCount += tweentyDollarCount;
        }


        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCentCount + money2.QuarterCentCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TweentyDollarCount + money2.TweentyDollarCount
                );

            return sum;
        }
    }
}
