using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zufapjt1
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.InitLog4Net(); // Log 모듈 생성
            LogManager.WriteCSLog(eLogLevel.Info, "Zu~");
        }
    }
}
