using System.Text.Json;
using PlatformService.Dtos;
using RabbitMQ.Client;
using System.Text;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration? _configuration;
        private readonly IConnection? _connection;
        private readonly IModel? _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;
                ConnectionFactory factory = new ConnectionFactory()
                {
                    HostName = _configuration["RabbitMQHost"],
                    Port = int.Parse(_configuration["RabbitMQPort"])
                };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.Write("--> Connected to MessageBus");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        public void PublishNewPlatform(PlatformPublishedDto platformPublishedDto)
        {
            string message = JsonSerializer.Serialize(platformPublishedDto);

            if (_connection != null && _connection.IsOpen)
            {
                Console.WriteLine("--> RabbitMQ Connection Open, sending message...");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("--> RabbitMQ connections closed, not sending messages...");
            }
        }

        public void Dispose()
        {
            Console.WriteLine("--> MessageBus Dispossed");
            if (_connection != null &&
                _channel != null &&
                _channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger",
                routingKey: "",
                basicProperties: null,
                body: body);
            Console.WriteLine($"--> We have sent {message}");
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs? e)
        {
            Console.WriteLine("--> RabbitMQ Connection Shutdown");
        }
    }
}