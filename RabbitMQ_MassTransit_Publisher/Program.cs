using MassTransit;
using RabbitMQ_MassTransit_Shared.Messages;

string rabbitMQUri = "amqps://dylxmqal:7_A9Vfo3nd5WpN62rVmsltBJBzUrG6SU@cow.rmq2.cloudamqp.com/dylxmqal";

string queueName = "example-queue";

var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
});

var sendEndPoint = await bus.GetSendEndpoint(new($"{rabbitMQUri}/{queueName}"));

Console.Write("Gönderilecek Mesaj : ");
string message = Console.ReadLine()!;

await sendEndPoint.Send<IMessage>(new ExampleMessage()
{
    Text = message!
});

Console.Read();