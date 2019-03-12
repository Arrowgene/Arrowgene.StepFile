using System.ComponentModel;
using System.Windows.Controls;

namespace Arrowgene.StepFile.Control.ArchiveTab
{
    public partial class ArchiveTabItemName : UserControl, INotifyPropertyChanged
    {
        private string _image;
        private string _text;

        public ArchiveTabItemName()
        {
            _image = null;
            _text = null;
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }
        public string Text { get { return _text; } set { _text = value; OnPropertyChanged("Text"); } }

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
