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
            new RabbitMQConsumer().Consume("item-stash-1");
            new RabbitMQConsumer().Consume("item-stash-2");

            Console.WriteLine("Type to exit...");
            Console.Read();
        }
    }
}
