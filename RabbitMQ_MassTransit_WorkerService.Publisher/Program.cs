using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ_MassTransit_WorkerService.Publisher.Services;

var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
{
    services.AddMassTransit(configurator =>
    {
        configurator.UsingRabbitMq((context, _configurator) =>
        {
            _configurator.Host("amqps://dylxmqal:7_A9Vfo3nd5WpN62rVmsltBJBzUrG6SU@cow.rmq2.cloudamqp.com/dylxmqal");
        });
    });

    services.AddHostedService<PublishMessageService>(provider =>
    {
        using IServiceScope scope = provider.CreateScope();
        IPublishEndpoint publishEndpoint = scope.ServiceProvider.GetService<IPublishEndpoint>()!;
        return new(publishEndpoint!);
    });
}).Build();

host.Run();