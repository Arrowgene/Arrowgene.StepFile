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

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabController : TabController
    {
        private Ez2OnBinFileTabControl _ez2OnBinFileTabControl;
        private Ez2OnBinFile _binFile;
        private object _selectedItem;


        public Ez2OnBinFileTabController() : base(new Ez2OnBinFileTabControl())
        {
            _ez2OnBinFileTabControl = TabUserControl as Ez2OnBinFileTabControl;
            Header = "Ez2On BinFile";

            _ez2OnBinFileTabControl.OpenCommand = new CommandHandler(OpenCommand, true);
            _ez2OnBinFileTabControl.SaveCommand = new CommandHandler(SaveCommand, true);
            _ez2OnBinFileTabControl.EditCommand = new CommandHandler(EditCommand, true);
            _ez2OnBinFileTabControl.AddCommand = new CommandHandler(AddCommand, true);
            _ez2OnBinFileTabControl.DeleteCommand = new CommandHandler(DeleteCommand, true);

            _ez2OnBinFileTabControl.ListViewItems.SelectionMode = SelectionMode.Single;
            _ez2OnBinFileTabControl.ListViewItems.MouseDoubleClick += ListViewItems_MouseDoubleClick;
        }

        private void OpenCommand()
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
            _ez2OnBinFileTabControl.ClearItems();
            _ez2OnBinFileTabControl.ClearColumns();
            if (_binFile is Ez2OnCardBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Text", TextField = "Text" });
                Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)_binFile;
                foreach (Ez2OnModelCard modelCard in cardBindFile.Entries)
                {
                    Ez2OnBinFileTabCard binFileTabCard = new Ez2OnBinFileTabCard(modelCard);
                    _ez2OnBinFileTabControl.AddItems(binFileTabCard);
                }
                Header = "Card";
            }
            else if (_binFile is Ez2OnIdFilterBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "IdFilter", TextField = "IdFilter" });
                Ez2OnIdFilterBinFile idFilterBinFile = (Ez2OnIdFilterBinFile)_binFile;
                foreach (string idFilter in idFilterBinFile.Entries)
                {
                    Ez2OnBinFileTabIdFilter binFileTabItem = new Ez2OnBinFileTabIdFilter(idFilter, idFilterBinFile);
                    _ez2OnBinFileTabControl.AddItems(binFileTabItem);
                }
                Header = "IdFilter";
            }
            else if (_binFile is Ez2OnItemBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Q", TextField = "Q" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Type", TextField = "Type" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "S", TextField = "S" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "T", TextField = "T" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "U", TextField = "U" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Image", TextField = "Image" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "A", TextField = "A" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Name", TextField = "Name" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "B", TextField = "B" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Duration", TextField = "Duration" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Coins", TextField = "Coins" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Level", TextField = "Level" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ExpPlus", TextField = "ExpPlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "CoinPlus", TextField = "CoinPlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "HpPlus", TextField = "HpPlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ResiliencePlus", TextField = "ResiliencePlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "DefensePlus", TextField = "DefensePlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "K", TextField = "K" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "L", TextField = "L" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "M", TextField = "M" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "N", TextField = "N" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "O", TextField = "O" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "V", TextField = "V" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "W", TextField = "W" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "X", TextField = "X" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Effect", TextField = "Effect" });
                Ez2OnItemBinFile itemBinFile = (Ez2OnItemBinFile)_binFile;
                foreach (Ez2OnModelItem modelItem in itemBinFile.Entries)
                {
                    Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelItem);
                    _ez2OnBinFileTabControl.AddItems(binFileTabItem);
                }
                Header = "Item";
            }
            else if (_binFile is Ez2OnMusicBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E1", TextField = "E1" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Name", TextField = "Name" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Category", TextField = "Category" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Duration", TextField = "Duration" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Bpm", TextField = "Bpm" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "FileName", TextField = "FileName" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D1", TextField = "D1" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D2", TextField = "D2" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzExr", TextField = "RubyEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D4", TextField = "D4" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzNotes", TextField = "RubyEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D6", TextField = "D6" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D7", TextField = "D7" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmExr", TextField = "RubyNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D9", TextField = "D9" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmNotes", TextField = "RubyNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D11", TextField = "D11" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D12", TextField = "D12" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdExr", TextField = "RubyHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D14", TextField = "D14" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdNotes", TextField = "RubyHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D16", TextField = "D16" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D17", TextField = "D17" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdExr", TextField = "RubyShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D19", TextField = "D19" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdNotes", TextField = "RubyShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D21", TextField = "D21" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D22", TextField = "D22" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzExr", TextField = "StreetEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D24", TextField = "D24" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzNotes", TextField = "StreetEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D26", TextField = "D26" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D27", TextField = "D27" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmExr", TextField = "StreetNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D29", TextField = "D29" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmNotes", TextField = "StreetNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D31", TextField = "D31" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D32", TextField = "D32" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdExr", TextField = "StreetHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D34", TextField = "D34" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdNotes", TextField = "StreetHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D36", TextField = "D36" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D37", TextField = "D37" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdExr", TextField = "StreetShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D39", TextField = "D39" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdNotes", TextField = "StreetShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D41", TextField = "D41" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D42", TextField = "D42" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzExr", TextField = "ClubEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D44", TextField = "D44" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzNotes", TextField = "ClubEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D46", TextField = "D46" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D47", TextField = "D47" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmExr", TextField = "ClubNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D49", TextField = "D49" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmNotes", TextField = "ClubNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D51", TextField = "D51" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D52", TextField = "D52" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdExr", TextField = "ClubHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D54", TextField = "D54" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdNotes", TextField = "ClubHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D56", TextField = "D56" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D57", TextField = "D57" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdExr", TextField = "ClubShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D59", TextField = "D59" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdNotes", TextField = "ClubShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D61", TextField = "D61" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E2", TextField = "E2" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E3", TextField = "E3" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E4", TextField = "E4" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E5", TextField = "E5" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E6", TextField = "E6" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E7", TextField = "E7" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E8", TextField = "E8" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E9", TextField = "E9" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E10", TextField = "E10" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E11", TextField = "E11" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E12", TextField = "E12" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E13", TextField = "E13" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E14", TextField = "E14" });
                Ez2OnMusicBinFile musicBinFile = (Ez2OnMusicBinFile)_binFile;
                foreach (Ez2onModelMusic modelMusic in musicBinFile.Entries)
                {
                    Ez2OnBinFileTabMusic binFileTabMusic = new Ez2OnBinFileTabMusic(modelMusic);
                    _ez2OnBinFileTabControl.AddItems(binFileTabMusic);
                }
                Header = "Music";
            }
            else if (_binFile is Ez2OnQuestBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "A", TextField = "A" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "B", TextField = "B" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "C", TextField = "C" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D", TextField = "D" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Title", TextField = "Title" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Mission", TextField = "Mission" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "G", TextField = "G" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "H", TextField = "H" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "I", TextField = "I" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "J", TextField = "J" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "K", TextField = "K" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "L", TextField = "L" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "M", TextField = "M" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "N", TextField = "N" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "O", TextField = "O" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "P", TextField = "P" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Q", TextField = "Q" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "R", TextField = "R" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "S", TextField = "S" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "T", TextField = "T" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "U", TextField = "U" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "V", TextField = "V" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "W", TextField = "W" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "X", TextField = "X" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Y", TextField = "Y" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z", TextField = "Z" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z1", TextField = "Z1" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z2", TextField = "Z2" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z3", TextField = "Z3" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z4", TextField = "Z4" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z5", TextField = "Z5" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z6", TextField = "Z6" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z7", TextField = "Z7" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z8", TextField = "Z8" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z9", TextField = "Z9" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z10", TextField = "Z10" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Z11", TextField = "Z11" });
                Ez2OnQuestBinFile questBinFile = (Ez2OnQuestBinFile)_binFile;
                foreach (Ez2OnModelQuest modelQuest in questBinFile.Entries)
                {
                    Ez2OnBinFileTabQuest binFileTabQuest = new Ez2OnBinFileTabQuest(modelQuest);
                    _ez2OnBinFileTabControl.AddItems(binFileTabQuest);
                }
                Header = "Quest";
            }
            else if (_binFile is Ez2OnRadiomixBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id" });
                Ez2OnRadiomixBinFile radioMixBinFile = (Ez2OnRadiomixBinFile)_binFile;
                foreach (Ez2OnModelRadiomix modelRadiomix in radioMixBinFile.Entries)
                {
                    Ez2OnBinFileTabRadiomix binFileTabRadiomix = new Ez2OnBinFileTabRadiomix(modelRadiomix);
                    _ez2OnBinFileTabControl.AddItems(binFileTabRadiomix);
                }
                Header = "Radiomix";
            }
            else
            {
                MessageBox.Show($"Can not read BinFile: '{selected.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private async void SaveCommand()
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
        private void DeleteCommand()
        {
        }

        private void AddCommand()
        {
        }

        private void EditCommand()
        {
        }

        private void ListViewItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _selectedItem = _ez2OnBinFileTabControl.ListViewItems.SelectedItem;
        }

    }
}
