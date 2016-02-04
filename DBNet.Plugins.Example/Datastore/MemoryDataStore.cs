using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBNet.Plugins.Example.Datastore
{
    public class MemoryDataStore
    {
        private static Dictionary<string, object> _dataStore;

        public Dictionary<string, object> Store
        {
            get { return _dataStore = _dataStore ?? new Dictionary<string, object>(); }
        }
    }
}
