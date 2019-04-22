using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.messageSenderBase = new MailSender();
            customerManager.Update();
            Console.ReadKey();

        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }

        public abstract void Send(Body body);

    }
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class MailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender", body.Title);
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase messageSenderBase { get; set; }
        public void Update()
        {
            messageSenderBase.Send(new Body { Title = "About the course" });
            Console.WriteLine("Customer updated.");
        }
    }




}
