using System;

namespace Lab_2
{

    abstract class AbstractMessage
    {
        public string Content { get; set;}
        abstract public void Send();
    }

    class EmailMessage : AbstractMessage
    {
        public string To { get; set;}
         public string From { get; set;}
        public string Subject { get; set; }
        public override void Send()
        {
            Console.WriteLine($"sending email from {From} with {Content}");;
        }
    }
        class SmsMessage : AbstractMessage
    {
    public string PhoneNumber { get; set; }
    public override void Send()
        {
            Console.WriteLine($"sending sms to {PhoneNumber} with {Content}");;
        }
    }

    interface IFly
    {
        void Fly();
    }
    interface ISwim
    {
        void Swim();
    }
    interface IFlyAndSwim: IFly, ISwim
    {

    }

    class Duck : IFlyAndSwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    class Hydroplane : IFlyAndSwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          string messageType = "email";

            switch (messageType)
            {
                case "email":
                    Console.WriteLine("Wysyłanie emaila");
                    break;
             case "sms":
                    Console.WriteLine("Wysyłanie emaila");
                    break;

            }
            AbstractMessage[] messages = new AbstractMessage[3];
            messages[0] = new EmailMessage() { Content = "Hello", From = "adam@op.pl", To = "", Subject = ""};
            messages[1] = new SmsMessage() { Content = "Hello", PhoneNumber = "123456789"};
            messages[2] = new EmailMessage() { Content = "Hello adam", From = "ola@op.pl", To = "", Subject = ""};
            int mailCouner = 0;
            foreach(var message in messages)
            {
                message.Send();
               // if (message is EmailMessage)
               // {
              //      mailCouner++;
              //  }
                EmailMessage email = message as EmailMessage;
                mailCouner += email == null ? 0 : 1;
            }
            Console.WriteLine($"Liczba emaili: {mailCouner}");
            IFly[] flyingObject = new IFly[3];
            flyingObject[0] = new Duck();
            flyingObject[1] = new Hydroplane();
            ISwim swimming = flyingObject[0] as ISwim;

            string[] names = { "Adam", "Ewa", "Karol" };
            IAggregate aggregate = new StringAggregate(names);
            aggregate = new SimpleAggregate() { FirstName = "Karol", LastName = "Okrasa" };
            Iterator iterator = aggregate.createIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
        }


       
    }
    interface IAggregate
    {
        Iterator createIterator();
    }
    interface Iterator
    {
        bool HasNext();
        string GetNext();
    }

    class SimpleAggregate : IAggregate
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Iterator createIterator()
        {
            return new SimpleAggregate(this);
        }
    }
    class SimpleIterator : Iterator
    {
        private SimpleAggregate Aggregate;
        private int count = 0;
        public string GetNext()
        {
            switch (count)
            {
                case 1:
                    return Aggregate.FirstName;
                case 2:
                    return Aggregate.LastName;
                default:
                    throw new Exception();
            }
        }

        public bool HasNext()
        {
            throw new NotImplementedException();
        }
    }

    class StringAggregate : IAggregate
    {
        internal string[] names;

        public StringAggregate(string[] names)
        {
            this.names = names;
        }

        public Iterator createIterator()
        {
            return new StringIterator(this);
        }
    }
    
    class StringIterator : Iterator
    {
        private StringAggregate aggregate;
        private int index = 0;
        public StringIterator(StringAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public string GetNext()
        {
            return aggregate.names[index++];
        }

        public bool HasNext()
        {
            return aggregate.names.Length > index;
        }
    }
}
// zad 1 + 2 + 3 