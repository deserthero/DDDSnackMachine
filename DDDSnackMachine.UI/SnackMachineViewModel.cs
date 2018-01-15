using DDDSnackMachine.UI.Common;
using SnackMachineATMAutomation.Logic;

namespace DDDSnackMachine.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;

        public override string Caption => "Snack Machine";

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
        }
    }
}
