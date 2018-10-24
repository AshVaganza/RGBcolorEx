using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _vm.Items.Add(new RgbCode
            {
                R = _vm.Code.R,
                G = _vm.Code.G,
                B = _vm.Code.B,
            });
        }
        public event EventHandler CanExecuteChanged;
    }
}
