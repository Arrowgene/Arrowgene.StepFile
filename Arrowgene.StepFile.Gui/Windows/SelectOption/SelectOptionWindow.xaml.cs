using System.Windows;
using System.Windows.Controls;

namespace Arrowgene.StepFile.Gui.Windows.SelectOption
{
    public partial class SelectOptionWindow : Window
    {
        private object selected;

        public SelectOptionWindow()
        {
            selected = null;
            InitializeComponent();
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetText(string text)
        {
            labelText.Content = text;
        }

        public void AddOption(object option, string name)
        {
            Button button = new Button();
            button.Content = name;
            button.Tag = option;
            button.Click += Button_Click;
            stackPanelOptions.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button == null)
            {

                DialogResult = false;
                Close();
            }
            selected = button.Tag;
            DialogResult = true;
            Close();
        }

        public object Select()
        {
            if (ShowDialog() == true)
            {
                return selected;
            }
            return null;
        }

    }
}
