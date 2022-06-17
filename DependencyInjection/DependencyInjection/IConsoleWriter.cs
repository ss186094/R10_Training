using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    interface IConsoleWriter
    {
        void LogMessage(string message);
    }
}
