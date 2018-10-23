using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBcolorEx
{
    public class RgbCode : INotifyPropertyChanged
    {
        private int _r;
        private int _g;
        private int _b;

        public int R
        {
            get { return _r; }
            set
            {
                _r = value;
                OnPropertyChanged("R");
            }
        }

        public int G
        {
            get { return _g; }
            set
            {
                _g = value;
                OnPropertyChanged("G");

            }
        }

        public int B
        {
            get { return _b; }
            set
            {
                _b = value;
                OnPropertyChanged("B");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
