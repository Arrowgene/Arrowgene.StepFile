using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;
using System;
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
            Width = 400;
            Height = 200;
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
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
            Width = 400;
            Height = 200;
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
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
            Width = 900;
            Height = 300;

            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(3, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
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
            gridContent.Children.Add(CreateLabel(0, 2, "Q"));
            gridContent.Children.Add(CreateTextBox(0, 3, "Q", binFileTabItem));
            gridContent.Children.Add(CreateLabel(0, 4, "Type"));
            gridContent.Children.Add(CreateComboBox(0, 5, "Type", binFileTabItem, typeof(ItemType)));
            gridContent.Children.Add(CreateLabel(0, 6, "S"));
            gridContent.Children.Add(CreateTextBox(0, 7, "S", binFileTabItem));

            gridContent.Children.Add(CreateLabel(1, 0, "Image"));
            gridContent.Children.Add(CreateTextBox(1, 1, "Image", binFileTabItem));
            gridContent.Children.Add(CreateLabel(1, 2, "T"));
            gridContent.Children.Add(CreateTextBox(1, 3, "T", binFileTabItem));
            gridContent.Children.Add(CreateLabel(1, 4, "U"));
            gridContent.Children.Add(CreateTextBox(1, 5, "U", binFileTabItem));
            gridContent.Children.Add(CreateLabel(1, 6, "A"));
            gridContent.Children.Add(CreateTextBox(1, 7, "A", binFileTabItem));

            gridContent.Children.Add(CreateLabel(2, 0, "Name"));
            gridContent.Children.Add(CreateTextBox(2, 1, "Name", binFileTabItem));
            gridContent.Children.Add(CreateLabel(2, 2, "B"));
            gridContent.Children.Add(CreateTextBox(2, 3, "B", binFileTabItem));
            gridContent.Children.Add(CreateLabel(2, 4, "Duration"));
            gridContent.Children.Add(CreateTextBox(2, 5, "Duration", binFileTabItem));
            gridContent.Children.Add(CreateLabel(2, 6, "Coins"));
            gridContent.Children.Add(CreateTextBox(2, 7, "Coins", binFileTabItem));

            gridContent.Children.Add(CreateLabel(3, 0, "Level"));
            gridContent.Children.Add(CreateTextBox(3, 1, "Level", binFileTabItem));
            gridContent.Children.Add(CreateLabel(3, 2, "ExpPlus"));
            gridContent.Children.Add(CreateTextBox(3, 3, "ExpPlus", binFileTabItem));
            gridContent.Children.Add(CreateLabel(3, 4, "CoinPlus"));
            gridContent.Children.Add(CreateTextBox(3, 5, "CoinPlus", binFileTabItem));
            gridContent.Children.Add(CreateLabel(3, 6, "HpPlus"));
            gridContent.Children.Add(CreateTextBox(3, 7, "HpPlus", binFileTabItem));

            gridContent.Children.Add(CreateLabel(4, 0, "ResiliencePlus"));
            gridContent.Children.Add(CreateTextBox(4, 1, "ResiliencePlus", binFileTabItem));
            gridContent.Children.Add(CreateLabel(4, 2, "DefensePlus"));
            gridContent.Children.Add(CreateTextBox(4, 3, "DefensePlus", binFileTabItem));
            gridContent.Children.Add(CreateLabel(4, 4, "K"));
            gridContent.Children.Add(CreateTextBox(4, 5, "K", binFileTabItem));
            gridContent.Children.Add(CreateLabel(4, 6, "L"));
            gridContent.Children.Add(CreateTextBox(4, 7, "L", binFileTabItem));

            gridContent.Children.Add(CreateLabel(5, 0, "M"));
            gridContent.Children.Add(CreateTextBox(5, 1, "M", binFileTabItem));
            gridContent.Children.Add(CreateLabel(5, 2, "N"));
            gridContent.Children.Add(CreateTextBox(5, 3, "N", binFileTabItem));
            gridContent.Children.Add(CreateLabel(5, 4, "O"));
            gridContent.Children.Add(CreateTextBox(5, 5, "O", binFileTabItem));
            gridContent.Children.Add(CreateLabel(5, 6, "V"));
            gridContent.Children.Add(CreateTextBox(5, 7, "V", binFileTabItem));

            gridContent.Children.Add(CreateLabel(6, 0, "Effect"));
            gridContent.Children.Add(CreateTextBox(6, 1, "Effect", binFileTabItem));
            gridContent.Children.Add(CreateLabel(6, 2, "W"));
            gridContent.Children.Add(CreateTextBox(6, 3, "W", binFileTabItem));
            gridContent.Children.Add(CreateLabel(6, 4, "X"));
            gridContent.Children.Add(CreateTextBox(6, 5, "X", binFileTabItem));
        }

        private void Open(Ez2OnBinFileTabMusic binFileTabMusic)
        {
            Width = 900;
            Height = 800;

            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            for (int i = 0; i <= 32; i++)
            {
                gridContent.RowDefinitions.Add(new RowDefinition()
                {
                    Height = GridLength.Auto
                });
            }
            gridContent.RowDefinitions[9].Height = new GridLength(10, GridUnitType.Pixel);
            gridContent.RowDefinitions[17].Height = new GridLength(10, GridUnitType.Pixel);
            gridContent.RowDefinitions[25].Height = new GridLength(10, GridUnitType.Pixel);

            gridContent.Children.Add(CreateLabel(0, 0, "Id"));
            gridContent.Children.Add(CreateTextBox(0, 1, "Id", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(1, 0, "Name"));
            gridContent.Children.Add(CreateTextBox(1, 1, "Name", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(2, 0, "Category"));
            gridContent.Children.Add(CreateComboBox(2, 1, "Category", binFileTabMusic, typeof(SongCategoryType)));
            gridContent.Children.Add(CreateLabel(3, 0, "Duration"));
            gridContent.Children.Add(CreateTextBox(3, 1, "Duration", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(4, 0, "Bpm"));
            gridContent.Children.Add(CreateTextBox(4, 1, "Bpm", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(1, 2, "Unknown"));
            gridContent.Children.Add(CreateTextBox(1, 3, "Unknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(2, 2, "FileName"));
            gridContent.Children.Add(CreateTextBox(2, 3, "FileName", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(3, 2, "New"));
            gridContent.Children.Add(CreateTextBox(3, 3, "New", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(4, 2, "LicensePrice"));
            gridContent.Children.Add(CreateTextBox(4, 3, "LicensePrice", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(10, 0, "RubyMix EZ"));
            gridContent.Children.Add(CreateLabel(11, 0, "RubyEzActivation"));
            gridContent.Children.Add(CreateTextBox(11, 1, "RubyEzActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(12, 0, "RubyEzExr"));
            gridContent.Children.Add(CreateTextBox(12, 1, "RubyEzExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(13, 0, "RubyEzUnknown"));
            gridContent.Children.Add(CreateTextBox(13, 1, "RubyEzUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(14, 0, "RubyEzNotes"));
            gridContent.Children.Add(CreateTextBox(14, 1, "RubyEzNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(15, 0, "RubyEzUnlock"));
            gridContent.Children.Add(CreateTextBox(15, 1, "RubyEzUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(16, 0, "RubyEzDjPoint"));
            gridContent.Children.Add(CreateTextBox(16, 1, "RubyEzDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(10, 2, "RubyMix NM"));
            gridContent.Children.Add(CreateLabel(11, 2, "RubyNmActivation"));
            gridContent.Children.Add(CreateTextBox(11, 3, "RubyNmActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(12, 2, "RubyNmExr"));
            gridContent.Children.Add(CreateTextBox(12, 3, "RubyNmExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(13, 2, "RubyNmUnknown"));
            gridContent.Children.Add(CreateTextBox(13, 3, "RubyNmUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(14, 2, "RubyNmNotes"));
            gridContent.Children.Add(CreateTextBox(14, 3, "RubyNmNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(15, 2, "RubyNmUnlock"));
            gridContent.Children.Add(CreateTextBox(15, 3, "RubyNmUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(16, 2, "RubyNmDjPoint"));
            gridContent.Children.Add(CreateTextBox(16, 3, "RubyNmDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(10, 4, "RubyMix HD"));
            gridContent.Children.Add(CreateLabel(11, 4, "RubyHdActivation"));
            gridContent.Children.Add(CreateTextBox(11, 5, "RubyHdActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(12, 4, "RubyHdExr"));
            gridContent.Children.Add(CreateTextBox(12, 5, "RubyHdExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(13, 4, "RubyHdUnknown"));
            gridContent.Children.Add(CreateTextBox(13, 5, "RubyHdUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(14, 4, "RubyHdNotes"));
            gridContent.Children.Add(CreateTextBox(14, 5, "RubyHdNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(15, 4, "RubyHdUnlock"));
            gridContent.Children.Add(CreateTextBox(15, 5, "RubyHdUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(16, 4, "RubyHdDjPoint"));
            gridContent.Children.Add(CreateTextBox(16, 5, "RubyHdDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(10, 6, "RubyMix SHD"));
            gridContent.Children.Add(CreateLabel(11, 6, "RubyShdActivation"));
            gridContent.Children.Add(CreateTextBox(11, 7, "RubyShdActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(12, 6, "RubyShdExr"));
            gridContent.Children.Add(CreateTextBox(12, 7, "RubyShdExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(13, 6, "RubyShdUnknown"));
            gridContent.Children.Add(CreateTextBox(13, 7, "RubyShdUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(14, 6, "RubyShdNotes"));
            gridContent.Children.Add(CreateTextBox(14, 7, "RubyShdNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(15, 6, "RubyShdUnlock"));
            gridContent.Children.Add(CreateTextBox(15, 7, "RubyShdUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(16, 6, "RubyShdDjPoint"));
            gridContent.Children.Add(CreateTextBox(16, 7, "RubyShdDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(18, 0, "StreetMix EZ"));
            gridContent.Children.Add(CreateLabel(19, 0, "StreetEzActivation"));
            gridContent.Children.Add(CreateTextBox(19, 1, "StreetEzActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(20, 0, "StreetEzExr"));
            gridContent.Children.Add(CreateTextBox(20, 1, "StreetEzExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(21, 0, "StreetEzUnknown"));
            gridContent.Children.Add(CreateTextBox(21, 1, "StreetEzUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(22, 0, "StreetEzNotes"));
            gridContent.Children.Add(CreateTextBox(22, 1, "StreetEzNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(23, 0, "StreetEzUnlock"));
            gridContent.Children.Add(CreateTextBox(23, 1, "StreetEzUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(24, 0, "StreetEzDjPoint"));
            gridContent.Children.Add(CreateTextBox(24, 1, "StreetEzDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(18, 2, "StreetMix NM"));
            gridContent.Children.Add(CreateLabel(19, 2, "StreetNmActivation"));
            gridContent.Children.Add(CreateTextBox(19, 3, "StreetNmActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(20, 2, "StreetNmExr"));
            gridContent.Children.Add(CreateTextBox(20, 3, "StreetNmExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(21, 2, "StreetNmUnknown"));
            gridContent.Children.Add(CreateTextBox(21, 3, "StreetNmUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(22, 2, "StreetNmNotes"));
            gridContent.Children.Add(CreateTextBox(22, 3, "StreetNmNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(23, 2, "StreetNmUnlock"));
            gridContent.Children.Add(CreateTextBox(23, 3, "StreetNmUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(24, 2, "StreetNmDjPoint"));
            gridContent.Children.Add(CreateTextBox(24, 3, "StreetNmDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(18, 4, "StreetMix HD"));
            gridContent.Children.Add(CreateLabel(19, 4, "StreetHdActivation"));
            gridContent.Children.Add(CreateTextBox(19, 5, "StreetHdActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(20, 4, "StreetHdExr"));
            gridContent.Children.Add(CreateTextBox(20, 5, "StreetHdExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(21, 4, "StreetHdUnknown"));
            gridContent.Children.Add(CreateTextBox(21, 5, "StreetHdUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(22, 4, "StreetHdNotes"));
            gridContent.Children.Add(CreateTextBox(22, 5, "StreetHdNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(23, 4, "StreetHdUnlock"));
            gridContent.Children.Add(CreateTextBox(23, 5, "StreetHdUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(24, 4, "StreetHdDjPoint"));
            gridContent.Children.Add(CreateTextBox(24, 5, "StreetHdDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(18, 6, "StreetMix SHD"));
            gridContent.Children.Add(CreateLabel(19, 6, "StreetShdActivation"));
            gridContent.Children.Add(CreateTextBox(19, 7, "StreetShdActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(20, 6, "StreetShdExr"));
            gridContent.Children.Add(CreateTextBox(20, 7, "StreetShdExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(21, 6, "StreetShdUnknown"));
            gridContent.Children.Add(CreateTextBox(21, 7, "StreetShdUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(22, 6, "StreetShdNotes"));
            gridContent.Children.Add(CreateTextBox(22, 7, "StreetShdNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(23, 6, "StreetShdUnlock"));
            gridContent.Children.Add(CreateTextBox(23, 7, "StreetShdUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(24, 6, "StreetShdDjPoint"));
            gridContent.Children.Add(CreateTextBox(24, 7, "StreetShdDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(26, 0, "ClubMix EZ"));
            gridContent.Children.Add(CreateLabel(27, 0, "ClubEzActivation"));
            gridContent.Children.Add(CreateTextBox(27, 1, "ClubEzActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(28, 0, "ClubEzExr"));
            gridContent.Children.Add(CreateTextBox(28, 1, "ClubEzExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(29, 0, "ClubEzUnknown"));
            gridContent.Children.Add(CreateTextBox(29, 1, "ClubEzUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(30, 0, "ClubEzNotes"));
            gridContent.Children.Add(CreateTextBox(30, 1, "ClubEzNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(31, 0, "ClubEzUnlock"));
            gridContent.Children.Add(CreateTextBox(31, 1, "ClubEzUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(32, 0, "ClubEzDjPoint"));
            gridContent.Children.Add(CreateTextBox(32, 1, "ClubEzDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(26, 2, "ClubMix NM"));
            gridContent.Children.Add(CreateLabel(27, 2, "ClubNmActivation"));
            gridContent.Children.Add(CreateTextBox(27, 3, "ClubNmActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(28, 2, "ClubNmExr"));
            gridContent.Children.Add(CreateTextBox(28, 3, "ClubNmExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(29, 2, "ClubNmUnknown"));
            gridContent.Children.Add(CreateTextBox(29, 3, "ClubNmUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(30, 2, "ClubNmNotes"));
            gridContent.Children.Add(CreateTextBox(30, 3, "ClubNmNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(31, 2, "ClubNmUnlock"));
            gridContent.Children.Add(CreateTextBox(31, 3, "ClubNmUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(32, 2, "ClubNmDjPoint"));
            gridContent.Children.Add(CreateTextBox(32, 3, "ClubNmDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(26, 4, "ClubMix HD"));
            gridContent.Children.Add(CreateLabel(27, 4, "ClubHdActivation"));
            gridContent.Children.Add(CreateTextBox(27, 5, "ClubHdActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(28, 4, "ClubHdExr"));
            gridContent.Children.Add(CreateTextBox(28, 5, "ClubHdExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(29, 4, "ClubHdUnknown"));
            gridContent.Children.Add(CreateTextBox(29, 5, "ClubHdUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(30, 4, "ClubHdNotes"));
            gridContent.Children.Add(CreateTextBox(30, 5, "ClubHdNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(31, 4, "ClubHdUnlock"));
            gridContent.Children.Add(CreateTextBox(31, 5, "ClubHdUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(32, 4, "ClubHdDjPoint"));
            gridContent.Children.Add(CreateTextBox(32, 5, "ClubHdDjPoint", binFileTabMusic));

            gridContent.Children.Add(CreateLabel(26, 6, "ClubMix SHD"));
            gridContent.Children.Add(CreateLabel(27, 6, "ClubShdActivation"));
            gridContent.Children.Add(CreateTextBox(27, 7, "ClubShdActivation", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(28, 6, "ClubShdExr"));
            gridContent.Children.Add(CreateTextBox(28, 7, "ClubShdExr", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(29, 6, "ClubShdUnknown"));
            gridContent.Children.Add(CreateTextBox(29, 7, "ClubShdUnknown", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(30, 6, "ClubShdNotes"));
            gridContent.Children.Add(CreateTextBox(30, 7, "ClubShdNotes", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(31, 6, "ClubShdUnlock"));
            gridContent.Children.Add(CreateTextBox(31, 7, "ClubShdUnlock", binFileTabMusic));
            gridContent.Children.Add(CreateLabel(32, 6, "ClubShdDjPoint"));
            gridContent.Children.Add(CreateTextBox(32, 7, "ClubShdDjPoint", binFileTabMusic));
        }

        private void Open(Ez2OnBinFileTabQuest binFileTabQuest)
        {
            Width = 600;
            Height = 400;

            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
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
            gridContent.Children.Add(CreateLabel(1, 0, "Title"));
            gridContent.Children.Add(SetSpan(CreateTextBox(1, 1, "Title", binFileTabQuest), 1, 7));
            gridContent.Children.Add(CreateLabel(2, 0, "Mission"));
            gridContent.Children.Add(SetSpan(CreateTextBox(2, 1, "Mission", binFileTabQuest), 1, 7));

            gridContent.Children.Add(CreateLabel(6, 0, "A"));
            gridContent.Children.Add(CreateTextBox(6, 1, "A", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(7, 0, "B"));
            gridContent.Children.Add(CreateTextBox(7, 1, "B", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(8, 0, "C"));
            gridContent.Children.Add(CreateTextBox(8, 1, "C", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(9, 0, "D"));
            gridContent.Children.Add(CreateTextBox(9, 1, "D", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(10, 0, "G"));
            gridContent.Children.Add(CreateTextBox(10, 1, "G", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(11, 0, "H"));
            gridContent.Children.Add(CreateTextBox(11, 1, "H", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(12, 0, "I"));
            gridContent.Children.Add(CreateTextBox(12, 1, "I", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(13, 0, "J"));
            gridContent.Children.Add(CreateTextBox(13, 1, "J", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(14, 0, "K"));
            gridContent.Children.Add(CreateTextBox(14, 1, "K", binFileTabQuest));

            gridContent.Children.Add(CreateLabel(6, 2, "L"));
            gridContent.Children.Add(CreateTextBox(6, 3, "L", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(7, 2, "M"));
            gridContent.Children.Add(CreateTextBox(7, 3, "M", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(8, 2, "N"));
            gridContent.Children.Add(CreateTextBox(8, 3, "N", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(9, 2, "O"));
            gridContent.Children.Add(CreateTextBox(9, 3, "O", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(10, 2, "P"));
            gridContent.Children.Add(CreateTextBox(10, 3, "P", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(11, 2, "Q"));
            gridContent.Children.Add(CreateTextBox(11, 3, "Q", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(12, 2, "R"));
            gridContent.Children.Add(CreateTextBox(12, 3, "R", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(13, 2, "S"));
            gridContent.Children.Add(CreateTextBox(13, 3, "S", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(14, 2, "T"));
            gridContent.Children.Add(CreateTextBox(14, 3, "T", binFileTabQuest));

            gridContent.Children.Add(CreateLabel(6, 4, "U"));
            gridContent.Children.Add(CreateTextBox(6, 5, "U", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(7, 4, "V"));
            gridContent.Children.Add(CreateTextBox(7, 5, "V", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(8, 4, "W"));
            gridContent.Children.Add(CreateTextBox(8, 5, "W", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(9, 4, "X"));
            gridContent.Children.Add(CreateTextBox(9, 5, "X", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(10, 4, "Y"));
            gridContent.Children.Add(CreateTextBox(10, 5, "Y", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(11, 4, "Z"));
            gridContent.Children.Add(CreateTextBox(11, 5, "Z", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(12, 4, "Z1"));
            gridContent.Children.Add(CreateTextBox(12, 5, "Z1", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(13, 4, "Z2"));
            gridContent.Children.Add(CreateTextBox(13, 5, "Z2", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(14, 4, "Z3"));
            gridContent.Children.Add(CreateTextBox(14, 5, "Z3", binFileTabQuest));

            gridContent.Children.Add(CreateLabel(6, 6, "Z4"));
            gridContent.Children.Add(CreateTextBox(6, 7, "Z4", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(7, 6, "Z5"));
            gridContent.Children.Add(CreateTextBox(7, 7, "Z5", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(8, 6, "Z6"));
            gridContent.Children.Add(CreateTextBox(8, 7, "Z6", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(9, 6, "Z7"));
            gridContent.Children.Add(CreateTextBox(9, 7, "Z7", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(10, 6, "Z8"));
            gridContent.Children.Add(CreateTextBox(10, 7, "Z8", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(11, 6, "Z9"));
            gridContent.Children.Add(CreateTextBox(11, 7, "Z9", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(12, 6, "Z10"));
            gridContent.Children.Add(CreateTextBox(12, 7, "Z10", binFileTabQuest));
            gridContent.Children.Add(CreateLabel(13, 6, "Z11"));
            gridContent.Children.Add(CreateTextBox(13, 7, "Z11", binFileTabQuest));
        }

        private void Open(Ez2OnBinFileTabRadiomix binFileTabRadiomix)
        {
            Width = 700;
            Height = 250;

            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = GridLength.Auto
            });
            gridContent.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });

            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });

            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });

            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });

            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            gridContent.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });

            gridContent.Children.Add(CreateLabel(0, 0, "RadiomixId"));
            gridContent.Children.Add(CreateTextBox(0, 1, "RadiomixId", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(0, 2, "B"));
            gridContent.Children.Add(CreateTextBox(0, 3, "B", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(0, 4, "C"));
            gridContent.Children.Add(CreateTextBox(0, 5, "C", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(0, 6, "D"));
            gridContent.Children.Add(CreateTextBox(0, 7, "D", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(0, 8, "E"));
            gridContent.Children.Add(CreateTextBox(0, 9, "E", binFileTabRadiomix));

            gridContent.Children.Add(CreateLabel(1, 0, "Song1Id"));
            gridContent.Children.Add(CreateTextBox(1, 1, "Song1Id", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(1, 2, "Song1RubyNotes"));
            gridContent.Children.Add(CreateTextBox(1, 3, "Song1RubyNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(1, 4, "Song1StreetNotes"));
            gridContent.Children.Add(CreateTextBox(1, 5, "Song1StreetNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(1, 6, "Song1ClubNotes"));
            gridContent.Children.Add(CreateTextBox(1, 7, "Song1ClubNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(1, 8, "Song1Club8KNotes"));
            gridContent.Children.Add(CreateTextBox(1, 9, "Song1Club8KNotes", binFileTabRadiomix));

            gridContent.Children.Add(CreateLabel(2, 0, "Song2Id"));
            gridContent.Children.Add(CreateTextBox(2, 1, "Song2Id", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(2, 2, "Song2RubyNotes"));
            gridContent.Children.Add(CreateTextBox(2, 3, "Song2RubyNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(2, 4, "Song2StreetNotes"));
            gridContent.Children.Add(CreateTextBox(2, 5, "Song2StreetNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(2, 6, "Song2ClubNotes"));
            gridContent.Children.Add(CreateTextBox(2, 7, "Song2ClubNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(2, 8, "Song2Club8KNotes"));
            gridContent.Children.Add(CreateTextBox(2, 9, "Song2Club8KNotes", binFileTabRadiomix));

            gridContent.Children.Add(CreateLabel(3, 0, "Song3Id"));
            gridContent.Children.Add(CreateTextBox(3, 1, "Song3Id", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(3, 2, "Song3RubyNotes"));
            gridContent.Children.Add(CreateTextBox(3, 3, "Song3RubyNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(3, 4, "Song3StreetNotes"));
            gridContent.Children.Add(CreateTextBox(3, 5, "Song3StreetNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(3, 6, "Song3ClubNotes"));
            gridContent.Children.Add(CreateTextBox(3, 7, "Song3ClubNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(3, 8, "Song3Club8KNotes"));
            gridContent.Children.Add(CreateTextBox(3, 9, "Song3Club8KNotes", binFileTabRadiomix));

            gridContent.Children.Add(CreateLabel(4, 0, "Song4Id"));
            gridContent.Children.Add(CreateTextBox(4, 1, "Song4Id", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(4, 2, "Song4RubyNotes"));
            gridContent.Children.Add(CreateTextBox(4, 3, "Song4RubyNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(4, 4, "Song4StreetNotes"));
            gridContent.Children.Add(CreateTextBox(4, 5, "Song4StreetNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(4, 6, "Song4ClubNotes"));
            gridContent.Children.Add(CreateTextBox(4, 7, "Song4ClubNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(4, 8, "Song4Club8KNotes"));
            gridContent.Children.Add(CreateTextBox(4, 9, "Song4Club8KNotes", binFileTabRadiomix));

            gridContent.Children.Add(CreateLabel(5, 0, "Total"));
            gridContent.Children.Add(CreateLabel(5, 3, "TotalRubyNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(5, 5, "TotalStreetNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(5, 7, "TotalClubNotes", binFileTabRadiomix));
            gridContent.Children.Add(CreateLabel(5, 9, "TotalCLub8KNotes", binFileTabRadiomix));
        }

        private Label CreateLabel(int row, int column, string text)
        {
            Label label = new Label();
            label.SetValue(Grid.RowProperty, row);
            label.SetValue(Grid.ColumnProperty, column);
            label.Content = $"{text}:";
            return label;
        }

        private Label CreateLabel(int row, int column, string bindingPath, object bindingSource)
        {
            Label label = new Label();
            label.SetValue(Grid.RowProperty, row);
            label.SetValue(Grid.ColumnProperty, column);
            Binding binding = new Binding(bindingPath);
            binding.Source = bindingSource;
            label.SetBinding(Label.ContentProperty, binding);
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

        private FrameworkElement SetSpan(FrameworkElement frameworkElement, int rowSpan, int columnSpan)
        {
            frameworkElement.SetValue(Grid.RowSpanProperty, rowSpan);
            frameworkElement.SetValue(Grid.ColumnSpanProperty, columnSpan);
            return frameworkElement;
        }

        private ComboBox CreateComboBox(int row, int column, string bindingPath, object bindingSource, Type enumType)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.SetValue(Grid.RowProperty, row);
            comboBox.SetValue(Grid.ColumnProperty, column);
            comboBox.ItemsSource = Enum.GetValues(enumType);
            Binding binding = new Binding(bindingPath);
            binding.Source = bindingSource;
            comboBox.SetBinding(ComboBox.SelectedValueProperty, binding);
            return comboBox;
        }


    }
}
