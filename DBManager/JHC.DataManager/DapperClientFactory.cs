using System;
using Microsoft.Extensions.Options;

namespace JHC.DataManager
{
    public class DapperClientFactory:IDapperClientFactory
    {
        private readonly IServiceProvider _services;
        private readonly IOptionsMonitor<DapperClientListOptions> _optionsMonitorClient;
        public DapperClientFactory(IServiceProvider services, IOptionsMonitor<DapperClientListOptions> optionsMonitorClient)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _optionsMonitorClient = optionsMonitorClient ?? throw new ArgumentNullException(nameof(optionsMonitorClient));
        }

        public DapperClient GetClient(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var clients = _optionsMonitorClient.Get("DbConnedtions").DapperDictionary;
            DapperClient client = null;
            foreach (var (key, value) in clients)
            {
                if (key == name)
                {
                    client = value;
                    break;
                }
            }
            return client;
        }
    }
}
