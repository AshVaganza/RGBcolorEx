using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace RGBcolorEx
{
    class ViewModel : INotifyPropertyChanged
    {
        private RgbCode _code;
        //private RgbCode _newItem;
        private RgbCode _selectedItem;
        public ICommand Add { get; }
        public ICommand Remove { get; }

        public ViewModel()
        {              
            Add = new AddCommand(this);
            Remove = new RemoveCommand(this);
            Items = new ObservableCollection<RgbCode>();
            _code = new RgbCode { R = 0, G = 0, B = 0 };
            _code.PropertyChanged += (sender, args) => OnPropertyChanged("Code");
        }

        public ObservableCollection<RgbCode> Items { get; set; }
        
        public RgbCode Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        public RgbCode SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        //public RgbCode NewItem
        //{
        //    get { return _newItem; }
        //    set
        //    {
        //        _newItem = value;
        //        OnPropertyChanged("NewItem");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
