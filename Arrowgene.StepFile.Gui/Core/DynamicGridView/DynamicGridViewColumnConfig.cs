using System.Collections.Generic;

namespace Arrowgene.StepFile.Core.DynamicGridView
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
