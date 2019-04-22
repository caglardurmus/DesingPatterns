using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadKey();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public abstract class Caching
    {
        public abstract void Cache(string message);
    }
    public class LogNet : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("LogNet");
        }
    }
    public class Log4 : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Log4");
        }
    }
    public class MemCash : Caching
    {
        public override void Cache(string message)
        {
            Console.WriteLine("MemCash");
        }
    }
    public class RedisCash : Caching
    {
        public override void Cache(string message)
        {
            Console.WriteLine("RedisCash");
        }
    }

    public abstract class CCCFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory1 : CCCFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCash();
        }

        public override Logging CreateLogger()
        {
            return new LogNet();
        }
    }
    public class Factory2 : CCCFactory
    {
        public override Caching CreateCaching()
        {
            return new MemCash();
        }

        public override Logging CreateLogger()
        {
            return new Log4();
        }
    }
    public class ProductManager
    {
        private CCCFactory _cccFactory;

        private Logging _logging;
        private Caching _caching;

        public ProductManager(CCCFactory cccFactory)
        {
            _cccFactory = cccFactory;
            _logging = _cccFactory.CreateLogger();
            _caching = _cccFactory.CreateCaching();
        }
        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Cached");
            Console.WriteLine("Products listed!");

        }
    }
}
