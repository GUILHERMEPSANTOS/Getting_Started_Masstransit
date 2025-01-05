using Microsoft.Extensions.DependencyInjection;

namespace Booking.Api.Extensions;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Booking.Application.AssemblyReference.Assembly);
        });

        return services;
    }
}