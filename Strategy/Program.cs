using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.creditCalculatorBase = new After2010CreditCalculator();
            customerManager.SaveCredit();

            customerManager.creditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();


            Console.ReadKey();
        }
    }

    abstract class CreditCalculaterBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculaterBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated before 2010");
        }
    }
    class After2010CreditCalculator : CreditCalculaterBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated after 2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculaterBase creditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer credi calculated.");
            creditCalculatorBase.Calculate();
        }
    }
}
