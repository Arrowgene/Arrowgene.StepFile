using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public partial class Ez2OnBinFileTabProperty : UserControl, INotifyPropertyChanged
    {
        private string _property;
        private string _value;
        private Action<int> _intSetter;
        private Action<string> _stringSetter;

        public Ez2OnBinFileTabProperty(string property, string value, Action<int> intSetter)
        {
            _property = property;
            _value = value;
            _intSetter = intSetter;
            DataContext = this;
            InitializeComponent();
        }

        public Ez2OnBinFileTabProperty(string property, string value, Action<string> stringSetter)
        {
            _property = property;
            _value = value;
            _stringSetter = stringSetter;
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Value
        {
            get { return _value; }
            set
            {
                if (_intSetter != null)
                {
                    if (int.TryParse(value, out int val))
                    {
                        _intSetter(val);
                        _value = value;
                        OnPropertyChanged("Value");
                    }
                }
                else if (_stringSetter != null)
                {
                    _stringSetter(value);
                    _value = value;
                    OnPropertyChanged("Value");
                }
                else
                {
                    // Error no setter
                }
            }
        }
        public string Property { get { return _property; } set { _property = value; OnPropertyChanged("Property"); } }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
