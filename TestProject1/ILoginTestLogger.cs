using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTests
{
    public interface ILoginTestLogger
    {
        void LogLoginStart(string username);
        void LogLoginSuccess();
    }
}
