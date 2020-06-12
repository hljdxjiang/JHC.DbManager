using System;
using System.Collections;
using System.Collections.Generic;

namespace JHC.DataManager
{
    public class DapperClientListOptions
    {
        public Dictionary<string, DapperClient> DapperDictionary { get; set; } =new Dictionary<string, DapperClient>();
    }
}
