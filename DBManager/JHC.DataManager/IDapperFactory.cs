using System;
using Dapper;
namespace JHC.DataManager
{
    public interface IDapperFactory
    {
        DapperClient CreateClient(string name);
    }
}
