using System;
using System.Collections.Generic;

namespace JHC.DataManager
{
    public class DapperFactoryOptions
    {
        public IList<Action<ConnectionConfig>> DapperActions { get; } = new List<Action<ConnectionConfig>>();
    }
}
