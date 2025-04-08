using CQRSLink.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCQRSLink(this IServiceCollection services, params Assembly[] assemblies)
    {
        // Register all handlers
        var handlerTypes = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .ToList();

        foreach (var handler in handlerTypes)
        {
            var interfaces = handler.GetInterfaces()
                .Where(i => i.IsGenericType &&
                    (i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>) ||
                     i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)));

            foreach (var i in interfaces)
            {
                services.AddTransient(i, handler);
            }
        }

        services.AddSingleton<ICQRSLink, CQRSLink.CQRSLink.CQRSLink>();

        return services;
    }
}
