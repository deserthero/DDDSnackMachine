using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachineATMAutomation.Logic
{
    //1-  We create it as a sealed, It's a good practice to give your code as few privileges as possible by default.
    public sealed class SnackMachine
    {
        // 2- We introduced separate props for each type of coins to know exactly how many of them in the machine right now.
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCentCount { get; private set; }
        public int OneDollarCount { get; private set; }
        public int FiveDollarCount { get; private set; }
        public int TweentyDollarCount { get; private set; }

        // 4- So we should create a transaction level record for the money
        public int OneCentCountInTransaction { get; private set; }
        public int TenCentCountInTransaction { get; private set; }
        public int QuarterCentCountInTransaction { get; private set; }
        public int OneDollarCountInTransaction { get; private set; }
        public int FiveDollarCountInTransaction { get; private set; }
        public int TweentyDollarCountInTransaction { get; private set; }

        // Insert Money will add the money to it's transaction level coins
        public void InsertMoney(int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int tweentyDollarCount)
        {
            OneCentCountInTransaction += oneCentCount;
            TenCentCountInTransaction += tenCentCount;
            QuarterCentCountInTransaction += quarterCentCount;
            OneDollarCountInTransaction += oneDollarCount;
            FiveDollarCountInTransaction += fiveDollarCount;
            TweentyDollarCountInTransaction += tweentyDollarCount;
        }

        //3- How we can return money if we don't have a separation between transaction and the overall money
        // Returns money will simulate this by give zero to all the transaction level members.
        public void ReturnsMoney()
        {
            OneCentCountInTransaction = 0;
            TenCentCountInTransaction = 0;
            QuarterCentCountInTransaction = 0;
            OneDollarCountInTransaction = 0;
            FiveDollarCountInTransaction = 0;
            TweentyDollarCountInTransaction = 0;
        }

        // This will add the transaction level money to the whole money coins then give zero to the transaction level ones
        public void BuySnack()
        {
            OneCentCount += OneCentCountInTransaction;
            TenCentCount += TenCentCountInTransaction;
            QuarterCentCount += QuarterCentCountInTransaction;
            OneDollarCount += OneDollarCountInTransaction;
            FiveDollarCount += FiveDollarCountInTransaction;
            TweentyDollarCount += TweentyDollarCountInTransaction;

            OneCentCountInTransaction = 0;
            TenCentCountInTransaction = 0;
            QuarterCentCountInTransaction = 0;
            OneDollarCountInTransaction = 0;
            FiveDollarCountInTransaction = 0;
            TweentyDollarCountInTransaction = 0;

        }


    }
}
