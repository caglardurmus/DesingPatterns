using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Save();

            Console.ReadKey();

        }
    }
    class Logging :ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    interface ILogging
    {
        void Log();
    }
    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }
    interface ICaching
    {
        void Cache();
    }
    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked!");
        }
    }
    interface IAuthorize
    {
        void CheckUser();
    }
    class Validation : IValidation
    {
        public void Validate()
        {
            Console.WriteLine("Validated!");
        }
    }
    interface IValidation
    {
        void Validate();
    }
    class CustomerManager                                                                             //      
    {                                                                                                 //
        private ILogging _logging;                                                                    //
        private ICaching _caching;                                                                    //
        private IAuthorize _authorize;                                                                //
                                                                                                      //
        public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)              //
        {                                                                                             //
            _logging = logging;                                                                       // bu normal yöntem
            _caching = caching;                                                                       //
            _authorize = authorize;                                                                   //
        }                                                                                             //
        public void Save()                                                                            //
        {                                                                                             //
            _logging.Log();                                                                           //
            _caching.Cache();                                                                         //
            _authorize.CheckUser();                                                                   //
            Console.WriteLine("Saved");                                                               //
        }                                                                                             //
    } 
    
    class ProductManager                                                                              ////yazılabilir.
    {                                                                                                 //
        private CrossFacade _crossFacade;                                                             //      
        public ProductManager()                                                                       //
        {                                                                                             //
            _crossFacade = new CrossFacade();                                                         //
        }                                                                                             //
        public void Save()                                                                            //
        {                                                                                             //
            _crossFacade.Logging.Log();                                                               //
            _crossFacade.Cachig.Cache();                                                              //
            _crossFacade.Authorize.CheckUser();                                                       //
            _crossFacade.Validation.Validate();                                                       //
            Console.WriteLine("Saved!");                                                              // Daha temiz
        }                                                                                             //
    }                                                                                                 //
                                                                                                      //
    class CrossFacade                                                                                 //
    {                                                                                                 //
        public ILogging Logging;                                                                      //
        public ICaching Cachig;                                                                       //
        public IAuthorize Authorize;                                                                  //
        public IValidation Validation;                                                                //
        public CrossFacade()                                                                          //
        {                                                                                             //
            Logging = new Logging();                                                                  //
            Cachig = new Caching();                                                                   //
            Authorize = new Authorize();                                                              //
            Validation = new Validation();                                                            //
        }                                                                                             //
    }                                                                                                 //

}

