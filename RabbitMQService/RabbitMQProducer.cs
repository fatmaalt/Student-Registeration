using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace student_registration.RabbitMQService
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "10.0.131.42";
            factory.UserName = "admin";
            factory.Password = "admin";
            factory.VirtualHost = "Training";
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclarePassive("Registration");
            //   channel.QueueDeclare("Registration");
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            //channel.QueueBind(queue: "Registration", exchange: "", routingKey: "Registration", b: body);

            channel.BasicPublish(exchange: "", routingKey: "Registration", body: body);
        }
    }
}