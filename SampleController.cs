using manyservices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manyservices
{

    [ApiController]
    public class SampleController : Controller
    {
        private readonly ServiceForModelProvider _serviceForModelProvider;

        public SampleController(ServiceForModelProvider serviceForModelProvider)
        {
            _serviceForModelProvider = serviceForModelProvider;
        }

        [Route("/hello/{model}")]
        [ModelService]
        public void SampleAction()
        {
            _serviceForModelProvider.Service.DoStuff();
        }

        [Route("/another")]
        [ModelService(ModelNameSource.Query)]
        public void AnotherSample(string model)
        {
            _serviceForModelProvider.Service.DoStuff();
        }

    }
}
