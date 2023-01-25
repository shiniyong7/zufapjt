using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zufapjt1
{
    class LogManager
    {
        static LogManager log4;
        private static ILog logger;
        private static ILog logdb;

        public static LogManager InitLog4Net()
        {
            if (log4 == null)
            {
                log4 = new LogManager();
            }

            return log4;
        }

        private LogManager()
        {
            string paths = Environment.CurrentDirectory;
            //실행위치에 config파일을 먼저 찾아본다.
            FileInfo File = new FileInfo(paths + @"\log.config");
            if (!File.Exists)
            {
                //실행위치에 없으면 프로젝트 루트를 검색.
                int indexnum = 0;
                indexnum = paths.IndexOf("\\bin");
                paths = paths.Remove(indexnum);
                File = new FileInfo(paths + @"\log.config");
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(File);

            logdb = log4net.LogManager.GetLogger("DB_Logger");
            logger = log4net.LogManager.GetLogger("PROGRAM_Logger");
        }
        private static void WriteLog(ILog logger, eLogLevel logLevel, string Text, params object[] args)
        {
            String sMessage = String.Format(Text, args);

            log4net.ThreadContext.Properties["level"] = "INFO";


            switch (logLevel)
            {
                case eLogLevel.Debug:
                    logger.Debug(sMessage);
                    break;
                case eLogLevel.Error:
                    logger.Error(sMessage);
                    break;
                case eLogLevel.Fatal:
                    logger.Fatal(sMessage);
                    break;
                case eLogLevel.Info:
                    logger.Info(sMessage);
                    break;
                case eLogLevel.Warn:
                    logger.Warn(sMessage);
                    break;
            }
        }

        public static void WriteCSLog(eLogLevel logLevel, string Text, params object[] args)
        {
            System.Console.WriteLine(Text, args);
            WriteLog(logdb, logLevel, Text, args);
            WriteLog(logger, logLevel, Text, args);
        }

    }
}
