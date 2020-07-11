using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Simple_Converter.Annotations;
using Simple_Converter.Command;

namespace Simple_Converter.ViewModel
{
    public class SimpleConverterViewModel : INotifyPropertyChanged
    {
        private string _binary;
        private string _decimal;
        private string _hexa;

        public string Binary 
        { get => _binary;
            set
            {
                if (_binary == value) return;
                _binary = value; OnPropertyChanged();
            } 
        }
        public string Decimal 
        { get => _decimal;
            set
            {
                if (_decimal == value) return;
                _decimal = value; OnPropertyChanged();
            } 
        }
        public string Hexa { get => _hexa;
            set
            {
                if (_hexa == value) return;
                _hexa = value;  OnPropertyChanged();
            } 
        }
        
        public ObservableCollection<bool?> RadiobuttonStatus { get; set; } // RadioButton
        public ObservableCollection<bool?> TextboxActive { get; set; } // TextBox
        public ObservableCollection<bool> TextboxReadonly { get; set; }
        public Calculate CCalculate { get; set; }
        public RadioPointsCommand Rpc { get; set; }
        public ButtonCommand BuC { get; set; }


        public SimpleConverterViewModel()
        {
            RadiobuttonStatus = new ObservableCollection<bool?>();
            TextboxActive = new ObservableCollection<bool?>();
            TextboxReadonly = new ObservableCollection<bool>();
            TextboxActive.Add(false);
            TextboxActive.Add(false);
            TextboxActive.Add(false);
            RadiobuttonStatus.Add(false);
            RadiobuttonStatus.Add(false);
            RadiobuttonStatus.Add(false);
            TextboxReadonly.Add(false);
            TextboxReadonly.Add(false);
            TextboxReadonly.Add(false);
            BuC = new ButtonCommand(this);
            Rpc = new RadioPointsCommand(this);
            CCalculate = new Calculate(this);
            
            Decimal = "0";
            Binary = "0";
            Hexa = "0";

        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}