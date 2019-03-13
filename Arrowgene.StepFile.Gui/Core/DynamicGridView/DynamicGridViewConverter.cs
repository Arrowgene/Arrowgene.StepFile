using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Arrowgene.StepFile.Gui.Core.DynamicGridView
{
    public class DynamicGridViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DynamicGridViewColumnConfig config = value as DynamicGridViewColumnConfig;
            if (config != null)
            {
                GridView grdiView = new GridView();
                foreach (var column in config.Columns)
                {
                    if (string.IsNullOrEmpty(column.ContentField))
                    {
                        Binding binding = new Binding(column.TextField);
                        binding.FallbackValue = "";
                        grdiView.Columns.Add(new GridViewColumn { Header = column.Header, DisplayMemberBinding = binding });
                    }
                    else
                    {
                        Binding binding = new Binding(column.ContentField);
                        DataTemplate template = new DataTemplate();
                        FrameworkElementFactory feFactory = new FrameworkElementFactory(typeof(ContentControl));
                        feFactory.SetBinding(ContentControl.ContentProperty, binding);
                        template.VisualTree = feFactory;
                        grdiView.Columns.Add(new GridViewColumn
                        {
                            Header = column.Header,
                            CellTemplate = template
                        });
                    }
                }
                return grdiView;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
