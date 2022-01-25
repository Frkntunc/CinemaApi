using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LoggerServices.Common
{
    public interface ILoggerService
    {
        Task Write(string message);
    }
}
