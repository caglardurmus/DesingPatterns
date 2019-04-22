using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productmanager = new ProductManager();
            productmanager.Attach(new CustomerObserver());
            productmanager.Attach(new EmployeeObserver());
            productmanager.UpdatePrice();
            
            Console.ReadKey();
        }
    }
    class ProductManager
    {
        List<Observer> _observer = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed.");
            Notify();
        }
        public void Attach(Observer observer)
        {
            _observer.Add(observer);
        }
        public void Detach(Observer observer)
        {
            _observer.Remove(observer);
        }
        private void Notify()
        {
            foreach (var observer in _observer)
            {
                observer.Update();
            }
        }

    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer: product price changed.");
        }

    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee: product price changed.");
        }

    }

}
