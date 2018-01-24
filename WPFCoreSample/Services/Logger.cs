using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoreSample.Services
{
    public class Logger : ILogger
    {
        public Logger()
        {
            Log("Logger created");
        }

        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
