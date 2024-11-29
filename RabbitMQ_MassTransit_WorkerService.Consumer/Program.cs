
using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMQ_MassTransit_WorkerService.Consumer.Consumers;

var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
{
    services.AddMassTransit(configurator =>
    {
        configurator.AddConsumer<ExampleMessageConsumer>();

        configurator.UsingRabbitMq((context,_configurator) =>
        {           
            _configurator.Host("amqps://dylxmqal:7_A9Vfo3nd5WpN62rVmsltBJBzUrG6SU@cow.rmq2.cloudamqp.com/dylxmqal");

            _configurator.ReceiveEndpoint("example-message-que",e => e.ConfigureConsumer<ExampleMessageConsumer>(context));
        });
    });
}).Build();

await host.RunAsync();

