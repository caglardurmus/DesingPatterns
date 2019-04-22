using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadKey();

        }
    }
    class ProductManager
    {
        ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved!");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}", message);
        }
    }
   
    
    //Nugget ten indirilmiş bir eklenti gibi düşün...Hiç bir şelilde dokunulamayan
    class Log4Net                      
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net, {0}", message);
        }

    }

    //adater oluşturduk ve interfaceden implement ettik.
    //böylelikle ProductManager a hiç dokunmadan çağırdık.
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }


}
