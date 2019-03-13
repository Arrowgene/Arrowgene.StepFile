using System.Collections.Generic;

namespace Arrowgene.StepFile.Gui.Core.DynamicGridView
{
    public class DynamicGridViewColumnConfig
    {
        public DynamicGridViewColumnConfig()
        {
            Columns = new List<DynamicGridViewColumn>();
        }

        public ICollection<DynamicGridViewColumn> Columns { get; }
    }

}
