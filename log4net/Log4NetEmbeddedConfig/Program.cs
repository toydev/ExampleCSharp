using log4net;
using log4net.Config;

using System;
using System.Reflection;

namespace Log4NetEmbeddedConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                XmlConfigurator.Configure(
                    assembly.GetManifestResourceStream("Log4NetEmbeddedConfig.Config.log.xml")
                );
                ILog logger = LogManager.GetLogger(typeof(Program));
                logger.Debug("Hello World");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
