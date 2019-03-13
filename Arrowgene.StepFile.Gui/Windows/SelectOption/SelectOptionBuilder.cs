namespace Arrowgene.StepFile.Gui.Windows.SelectOption
{
    public class SelectOptionBuilder<T>
    {

        private SelectOptionWindow _selectOptionWindow;

        public SelectOptionBuilder()
        {
            _selectOptionWindow = new SelectOptionWindow();
        }

        public SelectOptionBuilder<T> SetTitle(string title)
        {
            _selectOptionWindow.SetTitle(title);
            return this;
        }
        public SelectOptionBuilder<T> SetText(string text)
        {
            _selectOptionWindow.SetText(text);
            return this;
        }
        public SelectOptionBuilder<T> AddOption(T option, string name)
        {
            _selectOptionWindow.AddOption(option, name);
            return this;
        }

        public T Select()
        {
            object result = _selectOptionWindow.Select();
            return (T)result;
        }


    }
}
