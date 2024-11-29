using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMQ_MassTransit_Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_MassTransit_WorkerService.Publisher.Services
{
    public class PublishMessageService : BackgroundService
    {
        readonly IPublishEndpoint _publishEndEndpoint;

        public PublishMessageService(IPublishEndpoint publishEndEndpoint)
        {
            _publishEndEndpoint = publishEndEndpoint;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;
            while (true)
            {
                ExampleMessage message = new()
                {
                    Text = $"{++i}. mesaj"
                };
                await _publishEndEndpoint.Publish(message);
            }
        }
    }
}
