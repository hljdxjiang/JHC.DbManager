using System;
using Dapper;
namespace JHC.DataManager
{
    public interface IDapperClientFactory
    {
        DapperClient GetClient(string name);
    }
}
