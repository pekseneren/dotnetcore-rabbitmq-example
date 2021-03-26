using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitMQDev.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var consumer = new RabbitMQConsumer();
            consumer.Consume("item-stash-1");;

            var consumer2 = new RabbitMQConsumer();
            consumer2.Consume("item-stash-2");

            Console.WriteLine("Type to exit any time...");

            Console.Read();

            consumer.Dispose();
            consumer2.Dispose();
        }
    }
}
