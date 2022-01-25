using Core.LoggerServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LoggerServices
{
    public class DatabaseLogger : ILoggerService
    {
        public async Task Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
