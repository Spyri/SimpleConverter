using System;
using System.Windows.Input;
using Simple_Converter.ViewModel;

namespace Simple_Converter.Command
{
    public class RadioPointsCommand : ICommand
    {
        private readonly SimpleConverterViewModel _simpleConverterViewModel;

        public RadioPointsCommand(SimpleConverterViewModel simpleConverterViewModel)
        {
            _simpleConverterViewModel = simpleConverterViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_simpleConverterViewModel.RadiobuttonStatus[0] == true)
            {
                _simpleConverterViewModel.TextboxActive[0] = true;
                _simpleConverterViewModel.TextboxActive[2] = false;
                _simpleConverterViewModel.TextboxActive[1] = false;
                _simpleConverterViewModel.TextboxReadonly[0] = false;
                _simpleConverterViewModel.CCalculate.Clear();
            }
            if (_simpleConverterViewModel.RadiobuttonStatus[1] == true)
            {
                _simpleConverterViewModel.TextboxActive[1] = true;
                _simpleConverterViewModel.TextboxActive[2] = false;
                _simpleConverterViewModel.TextboxActive[0] = false;
                _simpleConverterViewModel.TextboxReadonly[1] = false;
                _simpleConverterViewModel.CCalculate.Clear();
            }
            if (_simpleConverterViewModel.RadiobuttonStatus[2] == true)
            {
                _simpleConverterViewModel.TextboxActive[2] = true;
                _simpleConverterViewModel.TextboxActive[1] = false;
                _simpleConverterViewModel.TextboxActive[0] = false;
                _simpleConverterViewModel.TextboxReadonly[2] = false;
                _simpleConverterViewModel.CCalculate.Clear();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}