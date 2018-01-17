using DDDSnackMachine.UI.Common;
using SnackMachineATMAutomation.Logic;

namespace DDDSnackMachine.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;

        public override string Caption => "Snack Machine";
        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _snackMachine.MoneyInside + _snackMachine.MoneyInTransaction;
        private string _message = "";
        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                Notify();
            }
        }
        // Commands for buttons
        public Command InsertCentCommand { get; private set; }
        public Command InsertTenCentCommand { get; private set; }
        public Command InsertQuarterCommand { get; private set; }
        public Command InsertDollarCommand { get; private set; }
        public Command InsertFiveDollarCommand { get; private set; }
        public Command InsertTwentyDollarCommand { get; private set; }
        public Command ReturnMoneyCommand { get; private set; }
        public Command BuySnackCommand { get; private set; }
        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;

            InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
            InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCommand = new Command(() => InsertMoney(Money.QuarterCent));
            InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
            InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TweentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command(() => BuySnack());
        }
        private void BuySnack()
        {
            _snackMachine.BuySnack();
            NotifyClient("You have bought a snack");
        }
        private void ReturnMoney()
        {
            _snackMachine.ReturnsMoney();
            NotifyClient("Money was returned");
        }
        private void InsertMoney(Money coinOrNote)
        {
            _snackMachine.InsertMoney(coinOrNote);
            NotifyClient("You have inserted: " + coinOrNote);
        }
        private void NotifyClient(string message)
        {
            Message = message;
            // This C# 7 prop instead of writing prop name
            Notify(nameof(MoneyInTransaction));
            Notify(nameof(MoneyInside));
        }

    }
}
