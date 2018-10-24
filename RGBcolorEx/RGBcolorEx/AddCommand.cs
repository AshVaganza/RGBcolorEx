using System;
using System.ComponentModel;
using System.Windows.Input;

namespace RGBcolorEx
{
    class AddCommand : ICommand
    {
        private ViewModel _vm;

        public AddCommand(ViewModel vm)
        {
            _vm = vm;
            _vm.PropertyChanged += VmOnPropertyChanged;
        }

        private void VmOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "Code")
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _vm.Code != null;
        }

        public void Execute(object parameter)
        {
            _vm.Items.Add(_vm.Code);
            _vm.Code = new RgbCode { R = 0, G = 0, B = 0 };
        }

        //_vm.Code.R = 0;
        //_vm.Code.G = 0;
        //_vm.Code.B = 0;

        public event EventHandler CanExecuteChanged;
    }
}
