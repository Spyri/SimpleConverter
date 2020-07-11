using System;
using System.Windows.Input;
using Simple_Converter.ViewModel;

namespace Simple_Converter.Command
{
    public class ButtonCommand : ICommand
    {
        private readonly SimpleConverterViewModel _simpleConverterViewModel;

        public ButtonCommand(SimpleConverterViewModel simpleConverterViewModel)
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
                _simpleConverterViewModel.Binary = _simpleConverterViewModel.CCalculate.DectoBit(_simpleConverterViewModel.Decimal);
                _simpleConverterViewModel.Hexa = _simpleConverterViewModel.CCalculate.DectoHex(_simpleConverterViewModel.Decimal);
                for (int i = 0; i < _simpleConverterViewModel.RadiobuttonStatus.Count; i++)
                {
                    _simpleConverterViewModel.RadiobuttonStatus[i] = false;
                    _simpleConverterViewModel.TextboxActive[i] = true;
                    _simpleConverterViewModel.TextboxReadonly[i] = true;
                }
            }
            if (_simpleConverterViewModel.RadiobuttonStatus[1] == true)
            {
                _simpleConverterViewModel.Binary = _simpleConverterViewModel.CCalculate.execute(_simpleConverterViewModel.Binary);
                _simpleConverterViewModel.Decimal = _simpleConverterViewModel.CCalculate.BittoDec(_simpleConverterViewModel.Binary);
                _simpleConverterViewModel.Hexa = _simpleConverterViewModel.CCalculate.BittoHex(_simpleConverterViewModel.Binary);
                if(_simpleConverterViewModel.Binary != string.Empty) _simpleConverterViewModel.Binary = _simpleConverterViewModel.Binary + "b";
                for (int i = 0; i < _simpleConverterViewModel.RadiobuttonStatus.Count; i++)
                {
                    _simpleConverterViewModel.RadiobuttonStatus[i] = false;
                    _simpleConverterViewModel.TextboxActive[i] = true;
                    _simpleConverterViewModel.TextboxReadonly[i] = true;
                }
            }
            if (_simpleConverterViewModel.RadiobuttonStatus[2] == true)
            {
                _simpleConverterViewModel.Hexa = _simpleConverterViewModel.CCalculate.execute(_simpleConverterViewModel.Hexa);
                _simpleConverterViewModel.Decimal = _simpleConverterViewModel.CCalculate.HextoDec(_simpleConverterViewModel.Hexa);
                _simpleConverterViewModel.Binary = _simpleConverterViewModel.CCalculate.HextoBit(_simpleConverterViewModel.Hexa);
                if(_simpleConverterViewModel.Hexa!= string.Empty) _simpleConverterViewModel.Hexa = _simpleConverterViewModel.Hexa + "h";
                for (int i = 0; i < _simpleConverterViewModel.RadiobuttonStatus.Count; i++)
                {
                    _simpleConverterViewModel.RadiobuttonStatus[i] = false;
                    _simpleConverterViewModel.TextboxActive[i] = true;
                    _simpleConverterViewModel.TextboxReadonly[i] = true;
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}