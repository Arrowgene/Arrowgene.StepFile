using System.Windows.Controls;
using System.Windows.Data;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public abstract class Ez2OnBinFileTabViewItem : DynamicGridViewItem
    {

        public Ez2OnBinFileTabViewItem()
        {

        }

        protected abstract object BindingSource { get; }

        protected TextBox Create(string propertyName)
        {
            TextBox textBox = new TextBox();
            Binding binding = new Binding(propertyName);
            binding.FallbackValue = "No Data";
            binding.Source = this;
            textBox.SetBinding(TextBox.TextProperty, binding);
            return textBox;
        }

    }
}
