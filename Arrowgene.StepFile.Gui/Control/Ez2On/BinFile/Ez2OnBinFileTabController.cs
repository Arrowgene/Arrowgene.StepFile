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

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabController : TabController
    {
        private Ez2OnBinFileTabControl _ez2OnBinFileTabControl;
        private Ez2OnBinFile _binFile;
        private Ez2OnBinFileTabViewItem _selectedItem;

        private CommandHandler _cmdEdit;
        private CommandHandler _cmdAdd;
        private CommandHandler _cmdDelete;
        private CommandHandler _cmdMoveUp;
        private CommandHandler _cmdMoveDown;

        public Ez2OnBinFileTabController() : base(new Ez2OnBinFileTabControl())
        {
            _ez2OnBinFileTabControl = TabUserControl as Ez2OnBinFileTabControl;
            Header = "Ez2On BinFile";

            _ez2OnBinFileTabControl.OpenCommand = new CommandHandler(OpenCommand, true);
            _ez2OnBinFileTabControl.SaveCommand = new CommandHandler(SaveCommand, true);
            _ez2OnBinFileTabControl.EditCommand = _cmdEdit = new CommandHandler(EditCommand, CanEdit);
            _ez2OnBinFileTabControl.AddCommand = _cmdAdd = new CommandHandler(AddCommand, CanAdd);
            _ez2OnBinFileTabControl.DeleteCommand = _cmdDelete = new CommandHandler(DeleteCommand, CanDelete);
            _ez2OnBinFileTabControl.MoveUpCommand = _cmdMoveUp = new CommandHandler(MoveUpCommand, CanMoveUp);
            _ez2OnBinFileTabControl.MoveDownCommand = _cmdMoveDown = new CommandHandler(MoveDownCommand, CanMoveDown);
            _ez2OnBinFileTabControl.ClearFilterCommand = new CommandHandler(ClearFilterCommand, true);

            _ez2OnBinFileTabControl.ListViewItems.SelectionMode = SelectionMode.Single;
            _ez2OnBinFileTabControl.ListViewItems.MouseDoubleClick += ListViewItems_MouseDoubleClick;
            _ez2OnBinFileTabControl.ListViewItems.SelectionChanged += ListViewItems_SelectionChanged;

            _ez2OnBinFileTabControl.TextBoxFilter.TextChanged += TextBoxFilter_TextChanged;
            _ez2OnBinFileTabControl.Filter += _ez2OnBinFileTabControl_Filter;
        }

        public void Open(FileInfo selected)
        {
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
            else if (_binFile is Ez2OnStrBinFile)
            {
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Text", TextField = "Text" });
                Ez2OnStrBinFile strBindFile = (Ez2OnStrBinFile)_binFile;
                foreach (Ez2OnModelStr modelStr in strBindFile.Entries)
                {
                    Ez2OnBinFileTabStr binFileTabStr = new Ez2OnBinFileTabStr(modelStr);
                    _ez2OnBinFileTabControl.AddItems(binFileTabStr);
                }
                Header = "Game String";
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
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Enabled", TextField = "Enabled" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Type", TextField = "Type" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "S", TextField = "S" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "T", TextField = "T" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "U", TextField = "U" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Image", TextField = "Image" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "A", TextField = "A" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Name", TextField = "Name" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Currency", TextField = "Currency" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Duration", TextField = "Duration" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Price", TextField = "Price" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Level", TextField = "Level" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "X", TextField = "X" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "DjPointPlus", TextField = "DjPointPlus" });
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
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Id", TextField = "Id", Width = 40 });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Unknown", TextField = "Unknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Name", TextField = "Name" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Category", TextField = "Category" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Duration", TextField = "Duration" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Bpm", TextField = "Bpm" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "FileName", TextField = "FileName" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "New", TextField = "New" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "LicensePrice", TextField = "LicensePrice" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzActivation", TextField = "RubyEzActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzExr", TextField = "RubyEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzUnknown", TextField = "RubyEzUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzNotes", TextField = "RubyEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzUnlock", TextField = "RubyEzUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyEzDjPoint", TextField = "RubyEzDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmActivation", TextField = "RubyNmActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmExr", TextField = "RubyNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmUnknown", TextField = "RubyNmUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmNotes", TextField = "RubyNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmUnlock", TextField = "RubyNmUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyNmDjPoint", TextField = "RubyNmDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdActivation", TextField = "RubyHdActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdExr", TextField = "RubyHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdNotes", TextField = "RubyHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdUnknown", TextField = "RubyHdUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdUnlock", TextField = "RubyHdUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyHdDjPoint", TextField = "RubyHdDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdActivation", TextField = "RubyShdActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdExr", TextField = "RubyShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdUnknown", TextField = "RubyShdUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdNotes", TextField = "RubyShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdUnlock", TextField = "RubyShdUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RubyShdDjPoint", TextField = "RubyShdDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzActivation", TextField = "StreetEzActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzExr", TextField = "StreetEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzUnknown", TextField = "StreetEzUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzNotes", TextField = "StreetEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzUnlock", TextField = "StreetEzUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetEzDjPoint", TextField = "StreetEzDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmActivation", TextField = "StreetNmActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmExr", TextField = "StreetNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmUnknown", TextField = "StreetNmUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmNotes", TextField = "StreetNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmUnlock", TextField = "StreetNmUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetNmDjPoint", TextField = "StreetNmDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdActivation", TextField = "StreetHdActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdExr", TextField = "StreetHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdUnknown", TextField = "StreetHdUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdNotes", TextField = "StreetHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdUnlock", TextField = "StreetHdUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetHdDjPoint", TextField = "StreetHdDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdActivation", TextField = "StreetShdActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdExr", TextField = "StreetShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdUnknown", TextField = "StreetShdUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdNotes", TextField = "StreetShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdUnlock", TextField = "StreetShdUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "StreetShdDjPoint", TextField = "StreetShdDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzActivation", TextField = "ClubEzActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzExr", TextField = "ClubEzExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzUnknown", TextField = "ClubEzUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzNotes", TextField = "ClubEzNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzUnlock", TextField = "ClubEzUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubEzDjPoint", TextField = "ClubEzDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmActivation", TextField = "ClubNmActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmExr", TextField = "ClubNmExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmUnknown", TextField = "ClubNmUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmNotes", TextField = "ClubNmNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmUnlock", TextField = "ClubNmUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubNmDjPoint", TextField = "ClubNmDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdActivation", TextField = "ClubHdActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdExr", TextField = "ClubHdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdUnknown", TextField = "ClubHdUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdNotes", TextField = "ClubHdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdUnlock", TextField = "ClubHdUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubHdDjPoint", TextField = "ClubHdDjPoint" });

                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdActivation", TextField = "ClubShdActivation" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdExr", TextField = "ClubShdExr" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdUnknown", TextField = "ClubShdUnknown" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdNotes", TextField = "ClubShdNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdUnlock", TextField = "ClubShdUnlock" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "ClubShdDjPoint", TextField = "ClubShdDjPoint" });

                Ez2OnMusicBinFile musicBinFile = (Ez2OnMusicBinFile)_binFile;
                foreach (Ez2OnModelMusic modelMusic in musicBinFile.Entries)
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
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "RadiomixId", TextField = "RadiomixId" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "B", TextField = "B" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "C", TextField = "C" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "D", TextField = "D" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "E", TextField = "E" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song1Id", TextField = "Song1Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song1RubyNotes", TextField = "Song1RubyNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song1StreetNotes", TextField = "Song1StreetNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song1ClubNotes", TextField = "Song1ClubNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song1Club8KNotes", TextField = "Song1Club8KNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song2Id", TextField = "Song2Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song2RubyNotes", TextField = "Song2RubyNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song2StreetNotes", TextField = "Song2StreetNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song2ClubNotes", TextField = "Song2ClubNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song2Club8KNotes", TextField = "Song2Club8KNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song3Id", TextField = "Song3Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song3RubyNotes", TextField = "Song3RubyNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song3StreetNotes", TextField = "Song3StreetNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song3ClubNotes", TextField = "Song3ClubNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song3Club8KNotes", TextField = "Song3Club8KNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song4Id", TextField = "Song4Id" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song4RubyNotes", TextField = "Song4RubyNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song4StreetNotes", TextField = "Song4StreetNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song4ClubNotes", TextField = "Song4ClubNotes" });
                _ez2OnBinFileTabControl.AddColumn(new DynamicGridViewColumn { Header = "Song4Club8KNotes", TextField = "Song4Club8KNotes" });
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
            }

            RaiseCmdChanged();
        }
        private void OpenCommand()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On StepFile(*.bin) | *.bin")
                .SelectSingle();
            Open(selected);
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

        private void AddCommand()
        {
            Ez2OnBinFileTabViewItem newItem = null;
            if (_binFile is Ez2OnCardBinFile)
            {
                Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)_binFile;
                Ez2OnModelCard modelCard = new Ez2OnModelCard();
                Ez2OnBinFileTabCard binFileTabCard = new Ez2OnBinFileTabCard(modelCard);
                cardBindFile.Entries.Add(modelCard);
                _ez2OnBinFileTabControl.AddItems(binFileTabCard);
                newItem = binFileTabCard;
            }
            else if (_binFile is Ez2OnStrBinFile)
            {
                Ez2OnStrBinFile strBindFile = (Ez2OnStrBinFile)_binFile;
                Ez2OnModelStr modelStr = new Ez2OnModelStr();
                Ez2OnBinFileTabStr binFileTabStr = new Ez2OnBinFileTabStr(modelStr);
                strBindFile.Entries.Add(modelStr);
                _ez2OnBinFileTabControl.AddItems(binFileTabStr);
                newItem = binFileTabStr;
            }
            else if (_binFile is Ez2OnIdFilterBinFile)
            {
                Ez2OnIdFilterBinFile idFilterBinFile = (Ez2OnIdFilterBinFile)_binFile;
                string idFilter = "New Id Filter";
                Ez2OnBinFileTabIdFilter binFileTabIdFilter = new Ez2OnBinFileTabIdFilter(idFilter, idFilterBinFile);
                idFilterBinFile.Entries.Add(idFilter);
                _ez2OnBinFileTabControl.AddItems(binFileTabIdFilter);
                newItem = binFileTabIdFilter;
            }
            else if (_binFile is Ez2OnItemBinFile)
            {
                Ez2OnItemBinFile itemBinFile = (Ez2OnItemBinFile)_binFile;
                Ez2OnModelItem modelItem = new Ez2OnModelItem();
                Ez2OnBinFileTabItem binFileTabItem = new Ez2OnBinFileTabItem(modelItem);
                itemBinFile.Entries.Add(modelItem);
                _ez2OnBinFileTabControl.AddItems(binFileTabItem);
                newItem = binFileTabItem;
            }
            else if (_binFile is Ez2OnMusicBinFile)
            {
                Ez2OnMusicBinFile musicBinFile = (Ez2OnMusicBinFile)_binFile;
                Ez2OnModelMusic modelMusic = new Ez2OnModelMusic();
                Ez2OnBinFileTabMusic binFileTabMusic = new Ez2OnBinFileTabMusic(modelMusic);
                musicBinFile.Entries.Add(modelMusic);
                _ez2OnBinFileTabControl.AddItems(binFileTabMusic);
                newItem = binFileTabMusic;
            }
            else if (_binFile is Ez2OnQuestBinFile)
            {
                Ez2OnQuestBinFile questBinFile = (Ez2OnQuestBinFile)_binFile;
                Ez2OnModelQuest modelQuest = new Ez2OnModelQuest();
                Ez2OnBinFileTabQuest binFileTabQuest = new Ez2OnBinFileTabQuest(modelQuest);
                questBinFile.Entries.Add(modelQuest);
                _ez2OnBinFileTabControl.AddItems(binFileTabQuest);
                newItem = binFileTabQuest;
            }
            else if (_binFile is Ez2OnRadiomixBinFile)
            {
                Ez2OnRadiomixBinFile radioMixBinFile = (Ez2OnRadiomixBinFile)_binFile;
                Ez2OnModelRadiomix modelRadiomix = new Ez2OnModelRadiomix();
                Ez2OnBinFileTabRadiomix binFileRadiomix = new Ez2OnBinFileTabRadiomix(modelRadiomix);
                radioMixBinFile.Entries.Add(modelRadiomix);
                _ez2OnBinFileTabControl.AddItems(binFileRadiomix);
                newItem = binFileRadiomix;
            }
            else
            {
                MessageBox.Show($"Can not add new entry", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (newItem != null)
            {
                _ez2OnBinFileTabControl.ListViewItems.ScrollIntoView(newItem);
                _ez2OnBinFileTabControl.ListViewItems.SelectedItem = newItem;
            }
            RaiseCmdChanged();
        }

        private bool CanAdd()
        {
            return true;
        }

        private void EditCommand()
        {
            Edit(_selectedItem);
        }

        private void Edit(Ez2OnBinFileTabViewItem item)
        {
            Ez2OnBinFileEditorWindow editorWindow = new Ez2OnBinFileEditorWindow(App.Window, item);
            if (editorWindow.ShowDialog() == true)
            {
                item.Save();
            }
            else
            {
                item.Discard();
            }
        }

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
            if (_selectedItem is Ez2OnBinFileTabCard && _binFile is Ez2OnCardBinFile)
            {
                Ez2OnBinFileTabCard binFileTabCard = (Ez2OnBinFileTabCard)_selectedItem;
                Ez2OnCardBinFile cardBindFile = (Ez2OnCardBinFile)_binFile;
                cardBindFile.Entries.Remove(binFileTabCard.Model);
                _ez2OnBinFileTabControl.RemoveItems(binFileTabCard);
            }
            else if (_selectedItem is Ez2OnBinFileTabStr && _binFile is Ez2OnStrBinFile)
            {
                Ez2OnBinFileTabStr binFileTabStr = (Ez2OnBinFileTabStr)_selectedItem;
                Ez2OnStrBinFile strBindFile = (Ez2OnStrBinFile)_binFile;
                strBindFile.Entries.Remove(binFileTabStr.Model);
                _ez2OnBinFileTabControl.RemoveItems(binFileTabStr);
            }
            else if (_selectedItem is Ez2OnBinFileTabIdFilter && _binFile is Ez2OnIdFilterBinFile)
            {
                Ez2OnBinFileTabIdFilter binFileTabIdFilter = (Ez2OnBinFileTabIdFilter)_selectedItem;
                Ez2OnIdFilterBinFile idFilterBinFile = (Ez2OnIdFilterBinFile)_binFile;
                idFilterBinFile.Entries.Remove(binFileTabIdFilter.Model);
                _ez2OnBinFileTabControl.RemoveItems(binFileTabIdFilter);
            }
            else if (_selectedItem is Ez2OnBinFileTabItem && _binFile is Ez2OnItemBinFile)
            {
                Ez2OnBinFileTabItem binFileTabItem = (Ez2OnBinFileTabItem)_selectedItem;
                Ez2OnItemBinFile itemBinFile = (Ez2OnItemBinFile)_binFile;
                itemBinFile.Entries.Remove(binFileTabItem.Model);
                _ez2OnBinFileTabControl.RemoveItems(binFileTabItem);
            }
            else if (_selectedItem is Ez2OnBinFileTabMusic && _binFile is Ez2OnMusicBinFile)
            {
                Ez2OnBinFileTabMusic binFileTabMusic = (Ez2OnBinFileTabMusic)_selectedItem;
                Ez2OnMusicBinFile musicBinFile = (Ez2OnMusicBinFile)_binFile;
                musicBinFile.Entries.Remove(binFileTabMusic.Model);
                _ez2OnBinFileTabControl.RemoveItems(binFileTabMusic);
            }
            else if (_selectedItem is Ez2OnBinFileTabQuest && _binFile is Ez2OnQuestBinFile)
            {
                Ez2OnBinFileTabQuest binFileTabQuest = (Ez2OnBinFileTabQuest)_selectedItem;
                Ez2OnQuestBinFile questBinFile = (Ez2OnQuestBinFile)_binFile;
                questBinFile.Entries.Remove(binFileTabQuest.Model);
                _ez2OnBinFileTabControl.RemoveItems(binFileTabQuest);
            }
            else if (_selectedItem is Ez2OnBinFileTabRadiomix && _binFile is Ez2OnRadiomixBinFile)
            {
                Ez2OnBinFileTabRadiomix binFileTabRadiomix = (Ez2OnBinFileTabRadiomix)_selectedItem;
                Ez2OnRadiomixBinFile radiomixBinFile = (Ez2OnRadiomixBinFile)_binFile;
                radiomixBinFile.Entries.Remove(binFileTabRadiomix.Model);
                _ez2OnBinFileTabControl.RemoveItems(binFileTabRadiomix);
            }
            else
            {
                MessageBox.Show($"Can not delete entry", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            if (selectedItem == null)
            {
                _selectedItem = null;
            }
            else if (selectedItem is Ez2OnBinFileTabViewItem)
            {
                _selectedItem = (Ez2OnBinFileTabViewItem)selectedItem;
            }
            RaiseCmdChanged();
        }

        private void ListViewItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object selectedItem = _ez2OnBinFileTabControl.ListViewItems.SelectedItem;
            if (selectedItem is Ez2OnBinFileTabViewItem)
            {
                Edit((Ez2OnBinFileTabViewItem)selectedItem);
            }
        }

        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ez2OnBinFileTabControl.SourceCollection.Refresh();
        }

        private void ClearFilterCommand()
        {
            _ez2OnBinFileTabControl.TextBoxFilter.Text = string.Empty;
        }

        private void _ez2OnBinFileTabControl_Filter(object sender, System.Windows.Data.FilterEventArgs e)
        {
            string filter = _ez2OnBinFileTabControl.TextBoxFilter.Text;
            if (string.IsNullOrEmpty(filter))
            {
                e.Accepted = true;
                return;
            }
            e.Accepted = false;

            if (e.Item is Ez2OnBinFileTabCard)
            {
                Ez2OnBinFileTabCard tabCard = (Ez2OnBinFileTabCard)e.Item;
                if (tabCard.Text.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
            }
            else if (e.Item is Ez2OnBinFileTabIdFilter)
            {
                Ez2OnBinFileTabIdFilter tabFilter = (Ez2OnBinFileTabIdFilter)e.Item;
                if (tabFilter.IdFilter.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
            }
            else if (e.Item is Ez2OnBinFileTabItem)
            {
                Ez2OnBinFileTabItem tabItem = (Ez2OnBinFileTabItem)e.Item;
                if (tabItem.Name.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
                if (tabItem.Image.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
                if (tabItem.Effect.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
            }
            else if (e.Item is Ez2OnBinFileTabMusic)
            {
                Ez2OnBinFileTabMusic tabMusic = (Ez2OnBinFileTabMusic)e.Item;
                if (tabMusic.Name.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
                if (tabMusic.FileName.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
                if (int.TryParse(filter, out int musicNumber))
                {
                    if (tabMusic.Id == musicNumber)
                    {
                        e.Accepted = true;
                        return;
                    }
                }
            }
            else if (e.Item is Ez2OnBinFileTabQuest)
            {
                Ez2OnBinFileTabQuest tabQuest = (Ez2OnBinFileTabQuest)e.Item;
                if (tabQuest.Title.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
                if (tabQuest.Mission.ToLower().Contains(filter))
                {
                    e.Accepted = true;
                    return;
                }
            }
            else if (e.Item is Ez2OnBinFileTabRadiomix)
            {
                Ez2OnBinFileTabRadiomix tabRadiomix = (Ez2OnBinFileTabRadiomix)e.Item;
                if (int.TryParse(filter, out int number))
                {
                    if (tabRadiomix.RadiomixId == number)
                    {
                        e.Accepted = true;
                        return;
                    }
                    if (tabRadiomix.Song1Id == number)
                    {
                        e.Accepted = true;
                        return;
                    }
                    if (tabRadiomix.Song2Id == number)
                    {
                        e.Accepted = true;
                        return;
                    }
                    if (tabRadiomix.Song3Id == number)
                    {
                        e.Accepted = true;
                        return;
                    }
                }
            }
            else
            {
                e.Accepted = true;
            }
        }

        private void Swap(DynamicGridViewItem itemA, DynamicGridViewItem itemB)
        {
            int idxA = _ez2OnBinFileTabControl.IndexOf(itemA);
            int idxB = _ez2OnBinFileTabControl.IndexOf(itemB);
            object binModelA = _binFile.GetEntry(idxA);
            object binModelB = _binFile.GetEntry(idxB);
            _binFile.SetEntry(idxB, binModelA);
            _binFile.SetEntry(idxA, binModelB);
            DynamicGridViewItem tmpA = _ez2OnBinFileTabControl.GetItem(idxA);
            DynamicGridViewItem tmpB = _ez2OnBinFileTabControl.GetItem(idxB);
            _ez2OnBinFileTabControl.SetItem(idxA, tmpB);
            _ez2OnBinFileTabControl.SetItem(idxB, tmpA);
            _ez2OnBinFileTabControl.ListViewItems.ScrollIntoView(itemA);
            _ez2OnBinFileTabControl.ListViewItems.SelectedIndex = idxB;
            RaiseCmdChanged();
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
