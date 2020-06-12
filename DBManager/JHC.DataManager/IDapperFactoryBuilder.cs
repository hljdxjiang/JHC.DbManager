using System;
using Microsoft.Extensions.DependencyInjection;

namespace JHC.DataManager
{
    public interface IDapperFactoryBuilder
    {
        string Name { get; }

        IServiceCollection Services { get; }
    }
}
