using System.ComponentModel;
using System.Windows.Controls;

namespace Arrowgene.StepFile.Control.Tab
{
    /// <summary>
    /// The tab instance.
    /// </summary>
    public abstract class TabUserControl : UserControl, ITab, INotifyPropertyChanged
    {
        public TabUserControl()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        TabUserControl ITab.TabUserControl => this;

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
