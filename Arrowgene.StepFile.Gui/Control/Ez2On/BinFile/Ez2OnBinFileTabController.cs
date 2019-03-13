using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.Ez2On.BinFile;
using System.IO;
using System.Windows;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;
using System.Threading.Tasks;
using Arrowgene.StepFile.Gui.Core.DynamicGridView;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabController : TabController
    {
        private Ez2OnBinFileTabControl _ez2OnBinFileTabControl;
        private Ez2OnBinFile _binFile;


        public Ez2OnBinFileTabController() : base(new Ez2OnBinFileTabControl())
        {
            _ez2OnBinFileTabControl = TabUserControl as Ez2OnBinFileTabControl;
            Header = "Ez2On BinFile";

            _ez2OnBinFileTabControl.OpenCommand = new CommandHandler(Open, true);
            _ez2OnBinFileTabControl.SaveCommand = new CommandHandler(Save, true);
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
            _ez2OnBinFileTabControl.ClearItems();
            _ez2OnBinFileTabControl.ClearColumns();
            if (_binFile is Ez2OnCardBinFile)
            {
                Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)_binFile;
                foreach (Ez2OnModelCard modelCard in cardBindFile.Entries)
                {

                }
                Header = "Card";
            }
            else if (_binFile is Ez2OnIdFilterBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Filter", ContentField = "Filter" });
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
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", ContentField = "Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Q", ContentField = "Q" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Type", ContentField = "Type" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "S", ContentField = "S" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "T", ContentField = "T" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "U", ContentField = "U" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Image", ContentField = "Image" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "A", ContentField = "A" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Name", ContentField = "Name" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "B", ContentField = "B" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Duration", ContentField = "Duration" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Coins", ContentField = "Coins" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Level", ContentField = "Level" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ExpPlus", ContentField = "ExpPlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "CoinPlus", ContentField = "CoinPlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "HpPlus", ContentField = "HpPlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ResiliencePlus", ContentField = "ResiliencePlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "DefensePlus", ContentField = "DefensePlus" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "K", ContentField = "K" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "L", ContentField = "L" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "M", ContentField = "M" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "N", ContentField = "N" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "O", ContentField = "O" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "V", ContentField = "V" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "W", ContentField = "W" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "X", ContentField = "X" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Effect", ContentField = "Effect" });
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
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", ContentField = "Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E1", ContentField = "E1" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Name", ContentField = "Name" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Category", ContentField = "Category" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Duration", ContentField = "Duration" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Bpm", ContentField = "Bpm" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "FileName", ContentField = "FileName" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D1", ContentField = "D1" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D2", ContentField = "D2" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzExr", ContentField = "RubyEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D4", ContentField = "D4" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzNotes", ContentField = "RubyEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D6", ContentField = "D6" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D7", ContentField = "D7" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmExr", ContentField = "RubyNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D9", ContentField = "D9" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmNotes", ContentField = "RubyNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D11", ContentField = "D11" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D12", ContentField = "D12" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdExr", ContentField = "RubyHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D14", ContentField = "D14" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdNotes", ContentField = "RubyHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D16", ContentField = "D16" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D17", ContentField = "D17" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdExr", ContentField = "RubyShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D19", ContentField = "D19" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdNotes", ContentField = "RubyShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D21", ContentField = "D21" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D22", ContentField = "D22" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzExr", ContentField = "StreetEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D24", ContentField = "D24" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzNotes", ContentField = "StreetEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D26", ContentField = "D26" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D27", ContentField = "D27" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmExr", ContentField = "StreetNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D29", ContentField = "D29" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmNotes", ContentField = "StreetNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D31", ContentField = "D31" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D32", ContentField = "D32" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdExr", ContentField = "StreetHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D34", ContentField = "D34" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdNotes", ContentField = "StreetHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D36", ContentField = "D36" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D37", ContentField = "D37" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdExr", ContentField = "StreetShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D39", ContentField = "D39" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdNotes", ContentField = "StreetShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D41", ContentField = "D41" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D42", ContentField = "D42" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzExr", ContentField = "ClubEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D44", ContentField = "D44" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzNotes", ContentField = "ClubEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D46", ContentField = "D46" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D47", ContentField = "D47" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmExr", ContentField = "ClubNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D49", ContentField = "D49" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmNotes", ContentField = "ClubNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D51", ContentField = "D51" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D52", ContentField = "D52" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdExr", ContentField = "ClubHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D54", ContentField = "D54" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdNotes", ContentField = "ClubHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D56", ContentField = "D56" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D57", ContentField = "D57" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdExr", ContentField = "ClubShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D59", ContentField = "D59" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdNotes", ContentField = "ClubShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D61", ContentField = "D61" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E2", ContentField = "E2" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E3", ContentField = "E3" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E4", ContentField = "E4" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E5", ContentField = "E5" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E6", ContentField = "E6" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E7", ContentField = "E7" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E8", ContentField = "E8" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E9", ContentField = "E9" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E10", ContentField = "E10" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E11", ContentField = "E11" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E12", ContentField = "E12" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E13", ContentField = "E13" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E14", ContentField = "E14" });
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
                Ez2OnQuestBinFile questBinFile = (Ez2OnQuestBinFile)_binFile;
                foreach (Ez2OnModelQuest modelQuest in questBinFile.Entries)
                {

                }
                Header = "Quest";
            }
            else if (_binFile is Ez2OnRadiomixBinFile)
            {
                Ez2OnRadiomixBinFile radioMixBinFile = (Ez2OnRadiomixBinFile)_binFile;
                foreach (Ez2OnModelRadiomix modelRadiomix in radioMixBinFile.Entries)
                {

                }
                Header = "Radiomix";
            }
            else
            {
                MessageBox.Show($"Can not read BinFile: '{selected.FullName}'", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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
