using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee caglar = new Employee { Name = "Caglar Durmus" };
            Employee songul = new Employee { Name = "Songul Sahin" };
            Employee ali = new Employee { Name = "ali" };
            Employee ahmet = new Employee { Name = "ahmet" };
            caglar.AddSubordinate(songul);
            caglar.AddSubordinate(ali);
            songul.AddSubordinate(ahmet);

            Contractor seyma = new Contractor { Name = "seyma" };
            songul.AddSubordinate(seyma);

            Console.WriteLine(caglar.Name);
            foreach (Employee manager in caglar)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("   {0}",employee.Name);
                }

            }

            Console.ReadLine();

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
