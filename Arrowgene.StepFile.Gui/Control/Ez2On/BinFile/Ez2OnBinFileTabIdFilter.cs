using Arrowgene.StepFile.Gui.Core.Ez2On.BinFile;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.BinFile
{
    public class Ez2OnBinFileTabIdFilter : Ez2OnBinFileTabViewItem
    {
        private Ez2OnIdFilterBinFile _idFilterBinFile;
        private string _idFilter;
        private string _currentIdFilter;

        public string IdFilter { get { return _idFilter; } set { _idFilter = value; OnPropertyChanged("IdFilter"); } }

        public Ez2OnBinFileTabIdFilter(string idFilter, Ez2OnIdFilterBinFile idFilterBinFile)
        {
            _currentIdFilter = idFilter;
            _idFilterBinFile = idFilterBinFile;
            Discard();
        }

        public override void Save()
        {
            _idFilterBinFile.Entries.Remove(_currentIdFilter);
            _idFilterBinFile.Entries.Add(IdFilter);
            _currentIdFilter = IdFilter;
        }

        public override void Discard()
        {
            IdFilter = _currentIdFilter;
        }
    }
}
