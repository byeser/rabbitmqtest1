using MassTransit;
using Shared;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Consumer
{ 
    public class Message : IMessage
    {
        public string Text { get; set; }
    }
    public class MessageConsumer : IConsumer<IMessage>
    {
        public async Task Consume(ConsumeContext<IMessage> context)
            => Console.WriteLine($"Gelen mesaj : {context.Message.Text}");
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            string rabbitMqUri = "rabbitmq://localhost/";
            string queue = "test-queue";

            string userName = "guest";
            string password = "123456";

            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMqUri, configurator =>
                {
                    configurator.Username(userName);
                    configurator.Password(password);
                });

                factory.ReceiveEndpoint(queue, endpoint => endpoint.Consumer<MessageConsumer>());
            });
            await bus.StartAsync();
            Console.ReadLine();
            await bus.StopAsync();
        }
    }
}
