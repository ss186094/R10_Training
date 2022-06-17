using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class CompositionRoot :ICompositionRoot
    {
        readonly IConsoleWriter consoleWriter;

        public CompositionRoot(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
            consoleWriter.LogMessage("Hello from CompositionRoot Constructor!");
        }
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
