using Booking.Common.Infrastructure;
using Catalog.Worker;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
       .Build();

services.AddCommonInfrastructure(config => { config.AddConsumer<AccommodationCreatedIntegrationEventConsumer>(); }, configuration);

var serviceProvider = services.BuildServiceProvider();

var busControl = serviceProvider.GetRequiredService<IBusControl>();
await busControl.StartAsync();

Console.WriteLine("Consumer rodando. Pressione qualquer tecla para sair...");
Console.ReadKey();

await busControl.StopAsync();