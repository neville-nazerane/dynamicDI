using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manyservices.Services
{
    public class ServiceForModelProvider
    {

        public static readonly Dictionary<string, Type> _pairs = new Dictionary<string, Type> {
            { "A", typeof(ServiceA) },
            { "B", typeof(ServiceB) }
        };
        private readonly IServiceProvider _serviceProvider;

        public IServiceForModel Service { get; private set; }

        public ServiceForModelProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IServiceForModel SetService(string key)
        {
            Service = (IServiceForModel) _serviceProvider.GetService(_pairs[key]);
            return Service;
        }

    }
}
