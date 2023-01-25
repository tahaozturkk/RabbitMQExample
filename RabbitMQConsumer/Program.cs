using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQConsumer
{
     class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("your_AMQP_URL");

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("messageQueue", false, false, false);
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume("messageQueue", false, consumer);
                consumer.Received += (sender, e) =>
                {
                   
                    Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
                };
            }
            Console.Read();
        }
    }
}