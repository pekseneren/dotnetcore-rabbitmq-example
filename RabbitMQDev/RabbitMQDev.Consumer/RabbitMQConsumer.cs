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
    public class RabbitMQConsumer : IDisposable
    {
        IConnection Connection;
        IModel Channel;
        private bool disposedValue;

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
                Connection = factory.CreateConnection();
                Channel = Connection.CreateModel();

                Console.WriteLine($"Lisening => {queue}");

                var consumer = new EventingBasicConsumer(Channel);

                consumer.Received += (sender, ea) => {

                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Channel.BasicAck(ea.DeliveryTag, false);
                    Console.WriteLine($"{queue}: Message received => {message}");
                };

                Channel.BasicConsume(queue, false, consumer);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{queue}: Something went wrong => {e.Message}");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    Connection.Dispose();
                    Channel.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RabbitMQConsumer()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
