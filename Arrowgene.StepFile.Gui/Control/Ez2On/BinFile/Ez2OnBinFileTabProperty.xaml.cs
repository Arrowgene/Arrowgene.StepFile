using System.ComponentModel;
using System.Windows.Controls;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public partial class Ez2OnBinFileTabProperty : UserControl, INotifyPropertyChanged
    {
        private string _property;
        private string _value;

        public Ez2OnBinFileTabProperty()
        {
            _property = null;
            _value = null;
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Property { get { return _property; } set { _property = value; OnPropertyChanged("Property"); } }
        public string Value { get { return _value; } set { _value = value; OnPropertyChanged("Value"); } }

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
