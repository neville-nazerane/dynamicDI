using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manyservices.Services
{
    public interface IServiceForModel
    {
        void DoStuff();
    }

    public class ServiceA : IServiceForModel
    {

        public void DoStuff()
        {
        }
    }

    public class ServiceB : IServiceForModel
    {

        public void DoStuff()
        {
        }
    }


}
