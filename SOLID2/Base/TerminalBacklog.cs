using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID2.Base
{
    public interface ITerminalBacklog
    {
        public void Log(string log);
    }
    public static class TerminalBacklog
    {
        public static void Log(string log)
        {
            Console.WriteLine(log);
        }
    }
}
