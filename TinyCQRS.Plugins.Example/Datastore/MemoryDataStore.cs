using System.Collections.Generic;

namespace TinyCQRS.Plugins.Example.Datastore
{
    public class MemoryDataStore
    {
        private static Dictionary<int, object> _dataStore;

        public Dictionary<int, object> Store
        {
            get { return _dataStore = _dataStore ?? new Dictionary<int, object>(); }
        }
    }
}
