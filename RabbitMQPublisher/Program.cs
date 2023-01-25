using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("your_AMQP_URL");
            //factory.HostName = "localhost";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("messageQueue", false, false, false);
                byte[] bytemessage = Encoding.UTF8.GetBytes("MessageContent");
                channel.BasicPublish(exchange: "", routingKey: "messageQueue", body: bytemessage);
            }
        }
    }
}