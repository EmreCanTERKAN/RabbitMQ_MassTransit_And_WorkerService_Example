using MassTransit;
using RabbitMQ_MassTransit_Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_MassTransit_Consumer.Consumers
{
    public class ExampleMessageConsumer : IConsumer<IMessage>
    {
        public Task Consume(ConsumeContext<IMessage> context)
        {
            Console.WriteLine("Gelen Mesaj" + context.Message.Text);
            return Task.CompletedTask;
        }
    }
}
