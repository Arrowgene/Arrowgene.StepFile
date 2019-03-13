using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.Ez2On.BinFile;
using System.IO;
using System.Windows;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabController : TabController
    {
        private Ez2OnBinFileTabControl _ez2OnBinFileTabControl;
        private ObservableCollection<UIElement> _items;


        public Ez2OnBinFileTabController() : base(new Ez2OnBinFileTabControl())
        {
            _ez2OnBinFileTabControl = TabUserControl as Ez2OnBinFileTabControl;
            _items = new ObservableCollection<UIElement>();
            Header = "Ez2On BinFile";

            _ez2OnBinFileTabControl.OpenCommand = new CommandHandler(Open, true);
            _ez2OnBinFileTabControl.SaveCommand = new CommandHandler(Save, true);
            _ez2OnBinFileTabControl.listViewItems.ItemsSource = _items;
        }
        private void Open()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On StepFile(*.bin) | *.bin")
                .SelectSingle();
            if (selected == null)
            {
                return;
            }
            Ez2OnBinFileIO binFileIO = new Ez2OnBinFileIO();
            Ez2OnBinFile binFile = binFileIO.Read(selected.FullName);
            List<Ez2OnBinFileTabItem> binFileTabItems = new List<Ez2OnBinFileTabItem>();
            if (binFile is Ez2OnCardBinFile)
            {
                Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)binFile;
                foreach (Ez2OnModelCard modelCard in cardBindFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelCard);
                    binFileTabItems.Add(binFileTabItem);
                }
            }
            else if (binFile is Ez2OnIdFilterBinFile)
            {
                Ez2OnIdFilterBinFile idFilterBinFile = (Ez2OnIdFilterBinFile)binFile;
                foreach (string idFilter in idFilterBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(idFilter);
                    binFileTabItems.Add(binFileTabItem);
                }
            }
            else if (binFile is Ez2OnItemBinFile)
            {
                Ez2OnItemBinFile itemBinFile = (Ez2OnItemBinFile)binFile;
                foreach (Ez2OnModelItem modelItem in itemBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelItem);
                    binFileTabItems.Add(binFileTabItem);
                }
            }
            else if (binFile is Ez2OnMusicBinFile)
            {
                Ez2OnMusicBinFile musicBinFile = (Ez2OnMusicBinFile)binFile;
                foreach (Ez2onModelMusic modelMusic in musicBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelMusic);
                    binFileTabItems.Add(binFileTabItem);
                }
            }
            else if (binFile is Ez2OnQuestBinFile)
            {
                Ez2OnQuestBinFile questBinFile = (Ez2OnQuestBinFile)binFile;
                foreach (Ez2OnModelQuest modelQuest in questBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelQuest);
                    binFileTabItems.Add(binFileTabItem);
                }
            }
            else if (binFile is Ez2OnRadiomixBinFile)
            {
                Ez2OnRadiomixBinFile radioMixBinFile = (Ez2OnRadiomixBinFile)binFile;
                foreach (Ez2OnModelRadiomix modelRadiomix in radioMixBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelRadiomix);
                    binFileTabItems.Add(binFileTabItem);
                }
            }
            else
            {
                MessageBox.Show($"Can not read BinFile: '{selected.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _items.Clear();
            List<UIElement> uiElements = CreateView(binFileTabItems);
            foreach (UIElement uiElement in uiElements)
            {
                _items.Add(uiElement);
            }
        }

        private List<UIElement> CreateView(List<Ez2OnBinFileTabItem> binFileTabItems)
        {
            List<UIElement> uiElements = new List<UIElement>();
            foreach (Ez2OnBinFileTabItem binFileTabItem in binFileTabItems)
            {
                StackPanel stackPanel = new StackPanel();
                foreach (UIElement property in binFileTabItem.Properties)
                {
                    stackPanel.Children.Add(property);
                }
                uiElements.Add(stackPanel);
            }
            return uiElements;
        }

        private void Save()
        {

        }
    }
}
