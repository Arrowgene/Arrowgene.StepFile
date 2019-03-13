using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.Ez2On.BinFile;
using System.IO;
using System.Windows;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabController : TabController
    {
        private Ez2OnBinFileTabControl _ez2OnBinFileTabControl;
        private ObservableCollection<UIElement> _items;
        private Ez2OnBinFile _binFile;


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
            _binFile = binFileIO.Read(selected.FullName);
            List<Ez2OnBinFileTabItem> binFileTabItems = new List<Ez2OnBinFileTabItem>();
            if (_binFile is Ez2OnCardBinFile)
            {
                Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)_binFile;
                foreach (Ez2OnModelCard modelCard in cardBindFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelCard);
                    binFileTabItems.Add(binFileTabItem);
                }
                Header = "Card";
            }
            else if (_binFile is Ez2OnIdFilterBinFile)
            {
                Ez2OnIdFilterBinFile idFilterBinFile = (Ez2OnIdFilterBinFile)_binFile;
                foreach (string idFilter in idFilterBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(idFilter);
                    binFileTabItems.Add(binFileTabItem);
                }
                Header = "IdFilter";
            }
            else if (_binFile is Ez2OnItemBinFile)
            {
                Ez2OnItemBinFile itemBinFile = (Ez2OnItemBinFile)_binFile;
                foreach (Ez2OnModelItem modelItem in itemBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelItem);
                    binFileTabItems.Add(binFileTabItem);
                }
                Header = "Item";
            }
            else if (_binFile is Ez2OnMusicBinFile)
            {
                Ez2OnMusicBinFile musicBinFile = (Ez2OnMusicBinFile)_binFile;
                foreach (Ez2onModelMusic modelMusic in musicBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelMusic);
                    binFileTabItems.Add(binFileTabItem);
                }
                Header = "Music";
            }
            else if (_binFile is Ez2OnQuestBinFile)
            {
                Ez2OnQuestBinFile questBinFile = (Ez2OnQuestBinFile)_binFile;
                foreach (Ez2OnModelQuest modelQuest in questBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelQuest);
                    binFileTabItems.Add(binFileTabItem);
                }
                Header = "Quest";
            }
            else if (_binFile is Ez2OnRadiomixBinFile)
            {
                Ez2OnRadiomixBinFile radioMixBinFile = (Ez2OnRadiomixBinFile)_binFile;
                foreach (Ez2OnModelRadiomix modelRadiomix in radioMixBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelRadiomix);
                    binFileTabItems.Add(binFileTabItem);
                }
                Header = "Radiomix";
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

        private async void Save()
        {
            FileInfo selected = new SaveFileBuilder()
                .Filter("Ez2On Bin File (.bin)|*.bin")
                .Select();
            if (selected == null)
            {
                return;
            }
            Ez2OnBinFileIO binFileIO = new Ez2OnBinFileIO();
            var task = Task.Run(() =>
            {
                binFileIO.Wrtire(selected.FullName, _binFile);
            });
            await task;
            App.ResetProgress(this);
        }
    }
}
