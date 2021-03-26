using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace RabbitMQDev.Producer
{
    public static class RabbitMQProducer
    {
        public static void SendItems(List<Item> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
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
                {
                    using (var channel = connection.CreateModel())
                    {
                        IBasicProperties properties = channel.CreateBasicProperties();

                        properties.Persistent = true;

                        items.ForEach(i =>
                        {
                            var serilazied = JsonSerializer.Serialize(i);

                            var body = Encoding.UTF8.GetBytes(serilazied);

                            channel.BasicPublish("item-exchange", i.StashCode, properties, body);

                            Console.WriteLine($"Message sended => [{serilazied}]");
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong => {ex.Message}");
            }
        }
    }
}
