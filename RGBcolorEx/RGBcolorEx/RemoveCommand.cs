using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RGBcolorEx
{
    class RemoveCommand : ICommand
    {
        private ViewModel _vm;

        public RemoveCommand(ViewModel vm)
        {
            _vm = vm;
            _vm.PropertyChanged += VmOnPropertyChanged;
        }

        private void VmOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedItem")
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_vm.SelectedItem != null)
            {
                SetSelectColor();
            }
            return _vm.SelectedItem != null;
        }

        public void Execute(object parameter)
        {
            _vm.Items.Remove(_vm.SelectedItem);
        }

        public event EventHandler CanExecuteChanged;

        private void SetSelectColor()
        {
            _vm.Code.R = _vm.SelectedItem.R;
            _vm.Code.G = _vm.SelectedItem.G;
            _vm.Code.B = _vm.SelectedItem.B;
        }

    }
}
