using Booking.Common.Application.EventBus;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Booking.Common.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services,
            Action<IRegistrationConfigurator> moduleConfigureConsumers)
        {
            services.TryAddSingleton<IEventBus, EventBus.EventBus>();

            services.AddMassTransit(x =>
            {
                moduleConfigureConsumers(x);
                
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}