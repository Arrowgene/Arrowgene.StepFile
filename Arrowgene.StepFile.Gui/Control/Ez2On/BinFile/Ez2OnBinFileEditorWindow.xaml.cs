using Arrowgene.StepFile.Gui.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public partial class Ez2OnBinFileEditorWindow : Window
    {

        public ICommand SaveCommand { get; }

        public Ez2OnBinFileEditorWindow(Window owner, Ez2OnBinFileTabViewItem item)
        {
            Owner = owner;
            DataContext = this;
            SaveCommand = new CommandHandler(Save, true);
            InitializeComponent();
            Open(item);
        }

        private void Save()
        {
            DialogResult = true;
            Close();
        }

        private void Open(Ez2OnBinFileTabViewItem item)
        {
            if (item is Ez2OnBinFileTabCard)
            {
                Ez2OnBinFileTabCard binFileTabCard = (Ez2OnBinFileTabCard)item;
                Open(binFileTabCard);
            }
            else if (item is Ez2OnBinFileTabIdFilter)
            {
                Ez2OnBinFileTabIdFilter binFileTabIdFilter = (Ez2OnBinFileTabIdFilter)item;
                Open(binFileTabIdFilter);
            }
            else if (item is Ez2OnBinFileTabItem)
            {
                Ez2OnBinFileTabItem binFileTabItem = (Ez2OnBinFileTabItem)item;
                Open(binFileTabItem);
            }
            else if (item is Ez2OnBinFileTabMusic)
            {
                Ez2OnBinFileTabMusic binFileTabMusic = (Ez2OnBinFileTabMusic)item;
                Open(binFileTabMusic);
            }
            else if (item is Ez2OnBinFileTabQuest)
            {
                Ez2OnBinFileTabQuest binFileTabQuest = (Ez2OnBinFileTabQuest)item;
                Open(binFileTabQuest);
            }
            else if (item is Ez2OnBinFileTabRadiomix)
            {
                Ez2OnBinFileTabRadiomix binFileTabRadiomix = (Ez2OnBinFileTabRadiomix)item;
                Open(binFileTabRadiomix);
            }
            else
            {
                MessageBox.Show($"Can not edit BinFile: '{item}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Open(Ez2OnBinFileTabCard binFileTabCard)
        {
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.Children.Add(CreateLabel(0, 0, "Id"));
            gridContent.Children.Add(CreateTextBox(0, 1, "Id", binFileTabCard));
            gridContent.Children.Add(CreateLabel(1, 0, "Text"));
            gridContent.Children.Add(CreateTextBox(1, 1, "Text", binFileTabCard));
        }

        private void Open(Ez2OnBinFileTabIdFilter binFileTabIdFilter)
        {
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.Children.Add(CreateLabel(0, 0, "IdFilter"));
            gridContent.Children.Add(CreateTextBox(0, 1, "IdFilter", binFileTabIdFilter));
        }

        private void Open(Ez2OnBinFileTabItem binFileTabItem)
        {
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.Children.Add(CreateLabel(0, 0, "Id"));
            gridContent.Children.Add(CreateTextBox(0, 1, "Id", binFileTabItem));
            gridContent.Children.Add(CreateLabel(1, 0, "Q"));
            gridContent.Children.Add(CreateTextBox(1, 1, "Q", binFileTabItem));
        }

        private void Open(Ez2OnBinFileTabMusic binFileTabMusic)
        {
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.Children.Add(CreateLabel(0, 0, "Id"));
            gridContent.Children.Add(CreateTextBox(0, 1, "Id", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(1, 0, "E1"));
            gridContent.Children.Add(CreateTextBox(1, 1, "E1", binFileTabMusic));
        }

        private void Open(Ez2OnBinFileTabQuest binFileTabQuest)
        {
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.Children.Add(CreateLabel(0, 0, "Id"));
            gridContent.Children.Add(CreateTextBox(0, 1, "Id", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(1, 0, "A"));
            gridContent.Children.Add(CreateTextBox(1, 1, "A", binFileTabQuest));
        }

        private void Open(Ez2OnBinFileTabRadiomix binFileTabRadiomix)
        {

        }

        private Label CreateLabel(int row, int column, string text)
        {
            Label label = new Label();
            label.SetValue(Grid.RowProperty, row);
            label.SetValue(Grid.ColumnProperty, column);
            label.Content = text;
            return label;
        }

        private TextBox CreateTextBox(int row, int column, string bindingPath, object bindingSource)
        {
            TextBox textBox = new TextBox();
            textBox.SetValue(Grid.RowProperty, row);
            textBox.SetValue(Grid.ColumnProperty, column);
            Binding binding = new Binding(bindingPath);
            binding.Source = bindingSource;
            textBox.SetBinding(TextBox.TextProperty, binding);
            return textBox;
        }

    }
}
