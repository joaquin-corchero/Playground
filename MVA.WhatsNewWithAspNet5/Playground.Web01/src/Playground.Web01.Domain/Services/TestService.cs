using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Web01.Domain.Services
{
    public interface ITestService
    {
        string GetString();
    }

    public class TestService : ITestService
    {
        public string GetString()
        {
            return "String from the service";
        }
    }
}
