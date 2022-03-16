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
         public string Subject { get; set;}
        abstract public void Send()
        {
            Console.WriteLine($"sending email from {From} with {Content}");;
        }
    }
        class SmsMessage : AbstractMessage
    {
        public string PhoneNumber { get; set;}
        abstract public void Send()
        {
            Console.WriteLine($"sending sms to {PhoneNumber} with {Content}");;
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
        }


       
    }
}
