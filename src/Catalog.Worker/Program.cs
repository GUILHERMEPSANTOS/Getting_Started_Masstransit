using Booking.Common.Infrastructure;
using Catalog.Worker;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddCommonInfrastructure(config => { config.AddConsumer<AccommodationCreatedIntegrationEventConsumer>(); });

var serviceProvider = services.BuildServiceProvider();

var busControl = serviceProvider.GetRequiredService<IBusControl>();
await busControl.StartAsync();

Console.WriteLine("Consumer rodando. Pressione qualquer tecla para sair...");
Console.ReadKey();

await busControl.StopAsync();