using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.Ez2On.BinFile;
using System.IO;
using System.Windows;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;
using System.Threading.Tasks;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Arrowgene.StepFile.Gui.Core.Ez2On.StrmFile;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.StrmFile
{
    public class Ez2OnStrmFileTabController : TabController
    {
        private Ez2OnStrmFileTabControl _ez2OnBinFileTabControl;
        private Ez2OnStrmFile _strmFile;
        private Ez2OnStrmFileTabViewItem _selectedItem;

        private CommandHandler _cmdEdit;
        private CommandHandler _cmdAdd;
        private CommandHandler _cmdDelete;
        private CommandHandler _cmdMoveUp;
        private CommandHandler _cmdMoveDown;

        public Ez2OnStrmFileTabController() : base(new Ez2OnStrmFileTabControl())
        {
            _ez2OnBinFileTabControl = TabUserControl as Ez2OnStrmFileTabControl;
            Header = "Ez2On StrmFile";

            _ez2OnBinFileTabControl.OpenCommand = new CommandHandler(OpenCommand, true);
            _ez2OnBinFileTabControl.SaveCommand = new CommandHandler(SaveCommand, true);
            _ez2OnBinFileTabControl.EditCommand = _cmdEdit = new CommandHandler(EditCommand, CanEdit);
            _ez2OnBinFileTabControl.AddCommand = _cmdAdd = new CommandHandler(AddCommand, CanAdd);
            _ez2OnBinFileTabControl.DeleteCommand = _cmdDelete = new CommandHandler(DeleteCommand, CanDelete);
            _ez2OnBinFileTabControl.MoveUpCommand = _cmdMoveUp = new CommandHandler(MoveUpCommand, CanMoveUp);
            _ez2OnBinFileTabControl.MoveDownCommand = _cmdMoveDown = new CommandHandler(MoveDownCommand, CanMoveDown);

            _ez2OnBinFileTabControl.ListViewItems.SelectionMode = SelectionMode.Single;
            _ez2OnBinFileTabControl.ListViewItems.MouseDoubleClick += ListViewItems_MouseDoubleClick;
            _ez2OnBinFileTabControl.ListViewItems.SelectionChanged += ListViewItems_SelectionChanged;
        }

        public void Open(FileInfo selected)
        {
            if (selected == null)
            {
                return;
            }
            Ez2OnStrmFileIO strmFileIO = new Ez2OnStrmFileIO();
            _strmFile = strmFileIO.Read(selected.FullName);

            _ez2OnBinFileTabControl.ClearItems();
            _ez2OnBinFileTabControl.ClearColumns();

            _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id" });
            _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Text", TextField = "Text" });

            //_ez2OnBinFileTabControl.AddItems(binFileTabCard);

            Header = "Card";

            RaiseCmdChanged();
        }
        private void OpenCommand()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On StrmFile(*.strm) | *.strm")
                .SelectSingle();
            Open(selected);
        }

        private async void SaveCommand()
        {
            FileInfo selected = new SaveFileBuilder()
              .Filter("Ez2On StrmFile(*.strm) | *.strm")
                .Select();
            if (selected == null)
            {
                return;
            }
            Ez2OnStrmFileIO strmFileIO = new Ez2OnStrmFileIO();
            var task = Task.Run(() =>
            {
                strmFileIO.Wrtire(selected.FullName, _strmFile);
            });
            await task;
            App.ResetProgress(this);
        }

        private void AddCommand()
        {
            // Ez2OnBinFileTabViewItem newItem = null;
            // if (_binFile is Ez2OnCardBinFile)
            // {
            //     Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)_binFile;
            //     Ez2OnModelCard modelCard = new Ez2OnModelCard();
            //     Ez2OnBinFileTabCard binFileTabCard = new Ez2OnBinFileTabCard(modelCard);
            //     cardBindFile.Entries.Add(modelCard);
            //     _ez2OnBinFileTabControl.AddItems(binFileTabCard);
            //     newItem = binFileTabCard;
            // }
            // else
            // {
            //     MessageBox.Show($"Can not add new entry", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            // }
            // if (newItem != null)
            // {
            //     _ez2OnBinFileTabControl.ListViewItems.ScrollIntoView(newItem);
            //     _ez2OnBinFileTabControl.ListViewItems.SelectedItem = newItem;
            // }
            RaiseCmdChanged();
        }

        private bool CanAdd()
        {
            return true;
        }

        private void EditCommand()
        {
            //     Edit(_selectedItem);
        }

        //  private void Edit(Ez2OnBinFileTabViewItem item)
        //   {
        //     Ez2OnBinFileEditorWindow editorWindow = new Ez2OnBinFileEditorWindow(App.Window, item);
        //     if (editorWindow.ShowDialog() == true)
        //     {
        //         item.Save();
        //     }
        //     else
        //     {
        //         item.Discard();
        //     }
        //  }

        private bool CanEdit()
        {
            if (_selectedItem == null)
            {
                return false;
            }
            return true;
        }

        private void DeleteCommand()
        {
            //   if (_selectedItem is Ez2OnBinFileTabCard && _binFile is Ez2OnCardBinFile)
            //   {
            //       Ez2OnBinFileTabCard binFileTabCard = (Ez2OnBinFileTabCard)_selectedItem;
            //       Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)_binFile;
            //       cardBindFile.Entries.Remove(binFileTabCard.Model);
            //       _ez2OnBinFileTabControl.RemoveItems(binFileTabCard);
            //   }
            //
            //   else
            //   {
            //       MessageBox.Show($"Can not delete entry", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            //   }
            RaiseCmdChanged();
        }

        private bool CanDelete()
        {
            if (_selectedItem == null)
            {
                return false;
            }
            return true;
        }

        private void MoveUpCommand()
        {
            int selectedIndex = _ez2OnBinFileTabControl.IndexOf(_selectedItem);
            DynamicGridViewItem itemA = _ez2OnBinFileTabControl.GetItem(selectedIndex);
            DynamicGridViewItem itemB = _ez2OnBinFileTabControl.GetItem(selectedIndex + 1);
            Swap(itemA, itemB);
        }

        private bool CanMoveUp()
        {
            if (_ez2OnBinFileTabControl.ListViewItems.SelectedIndex < 0)
            {
                return false;
            }
            if (_ez2OnBinFileTabControl.ListViewItems.SelectedIndex >= _ez2OnBinFileTabControl.ListViewItems.Items.Count - 1)
            {
                return false;
            }
            return true;
        }

        private void MoveDownCommand()
        {
            int selectedIndex = _ez2OnBinFileTabControl.IndexOf(_selectedItem);
            DynamicGridViewItem itemA = _ez2OnBinFileTabControl.GetItem(selectedIndex);
            DynamicGridViewItem itemB = _ez2OnBinFileTabControl.GetItem(selectedIndex - 1);
            Swap(itemA, itemB);
        }

        private bool CanMoveDown()
        {
            if (_ez2OnBinFileTabControl.ListViewItems.SelectedIndex <= 0)
            {
                return false;
            }
            return true;
        }

        private void ListViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = _ez2OnBinFileTabControl.ListViewItems.SelectedItem;
            //    if (selectedItem == null)
            //    {
            //        _selectedItem = null;
            //    }
            //    else if (selectedItem is Ez2OnBinFileTabViewItem)
            //    {
            //        _selectedItem = (Ez2OnBinFileTabViewItem)selectedItem;
            //    }
            RaiseCmdChanged();
        }

        private void ListViewItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object selectedItem = _ez2OnBinFileTabControl.ListViewItems.SelectedItem;
            //     if (selectedItem is Ez2OnBinFileTabViewItem)
            //     {
            //         Edit((Ez2OnBinFileTabViewItem)selectedItem);
            //     }
        }

        private void Swap(DynamicGridViewItem itemA, DynamicGridViewItem itemB)
        {
         //  int idxA = _ez2OnBinFileTabControl.IndexOf(itemA);
         //  int idxB = _ez2OnBinFileTabControl.IndexOf(itemB);
         //  object binModelA = _binFile.GetEntry(idxA);
         //  object binModelB = _binFile.GetEntry(idxB);
         //  _binFile.SetEntry(idxB, binModelA);
         //  _binFile.SetEntry(idxA, binModelB);
         //  DynamicGridViewItem tmpA = _ez2OnBinFileTabControl.GetItem(idxA);
         //  DynamicGridViewItem tmpB = _ez2OnBinFileTabControl.GetItem(idxB);
         //  _ez2OnBinFileTabControl.SetItem(idxA, tmpB);
         //  _ez2OnBinFileTabControl.SetItem(idxB, tmpA);
         //  _ez2OnBinFileTabControl.ListViewItems.ScrollIntoView(itemA);
         //  _ez2OnBinFileTabControl.ListViewItems.SelectedIndex = idxB;
         //  RaiseCmdChanged();
        }

        private void RaiseCmdChanged()
        {
            _cmdAdd.RaiseCanExecuteChanged();
            _cmdEdit.RaiseCanExecuteChanged();
            _cmdDelete.RaiseCanExecuteChanged();
            _cmdMoveDown.RaiseCanExecuteChanged();
            _cmdMoveUp.RaiseCanExecuteChanged();
        }

    }
}
