using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccesor(vicePresident);
            vicePresident.SetSuccesor(president);

            Expence expence = new Expence();
            expence.Amount = 198;
            manager.HandleExpence(expence);

            Console.ReadKey();

        }
    }

    class Expence
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
   abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpence(Expence expence);
        public void SetSuccesor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }
    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpence(Expence expence)
        {
            if (expence.Amount <= 100)
            {
                Console.WriteLine("Manager handle it.");
            }
            else if (Successor != null)
            {
                Successor.HandleExpence(expence);
            }
        }

    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpence(Expence expence)
        {
            if (expence.Amount > 100 && expence.Amount <=1000)
            {
                Console.WriteLine("Vice President handle it.");
            }
            else if (Successor != null)
            {
                Successor.HandleExpence(expence);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpence(Expence expence)
        {
            if (expence.Amount > 1000)
            {
                Console.WriteLine("President handle it.");
            }
           
        }
    }

}
