using Booking.Common.Application.EventBus;
using Booking.Common.Infrastructure.EventBus;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Booking.Common.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services,
            Action<IRegistrationConfigurator> moduleConfigureConsumers, IConfiguration configuration)
        {
            var busSetting = new BusSetting();
            configuration.GetSection("BusSetting").Bind(busSetting);


            if (busSetting.Enabled)
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
            }
            else
            {
                services.TryAddSingleton<IEventBus, FakeEventBus>();
            }

            services.TryAddSingleton<IEventBus, EventBus.EventBus>();

            return services;
        }
    }
}