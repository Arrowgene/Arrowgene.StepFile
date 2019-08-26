using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arrowgene.StepFile.Gui.Windows.Main
{
    public interface IMainWindow
    {
        Window Window { get; }
        TabControl TabControl { get; }
        ICommand Ez2OnArchiveCommand { get; set; }
        ICommand Ez2OnStepFileCommand { get; set; }
        ICommand LogTabCommand { get; set; }
        ICommand SettingTabCommand { get; set; }
        ICommand Ez2OnDotBinCommand { get; set; }
        ICommand Ez2OnDotStrmCommand { get; set; }
        ICommand BuildCommand { get; set; }
        int ProgressBarValue { get; set; }
        string ProgressBarText { get; set; }
    }
}
