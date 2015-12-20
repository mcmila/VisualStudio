using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProject.MVC7Days.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("C://Error//" + DateTime.Now.ToString("dd-MM-yyyy mm hh ss") + ".txt",
                new[]
                {
                    "Message:"+e.Message,
                    "Stacktrace:"+e.StackTrace
                });
        }
    }
}
