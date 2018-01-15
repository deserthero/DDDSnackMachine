using SnackMachineATMAutomation.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSnackMachine.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            var viewModel = new SnackMachineViewModel(new SnackMachine());
            _dialogService.ShowDialog(viewModel);
        }
    }
}
