using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQDev.Consumer
{
    public class RabbitMQConsumer
    {
        public void Consume(string queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password",
                VirtualHost = "/",
                Port = 5672
            };

            try
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    Console.WriteLine($"Lisening => {queue}");

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (sender, ea) => {

                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine($"{queue}: Message received => {message}");

                        Thread.Sleep(1000);

                        channel.BasicAck(ea.DeliveryTag, false);
                    };

                    channel.BasicConsume(queue, false, consumer);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{queue}: Something went wrong => {e.Message}");
            }
        }
    }
}
