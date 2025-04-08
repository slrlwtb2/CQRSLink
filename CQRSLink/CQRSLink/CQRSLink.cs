using CQRSLink.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace CQRSLink.CQRSLink
{
    public class CQRSLink : ICQRSLink
    {
        private readonly IServiceProvider _serviceProvider;

        public CQRSLink(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> SendCommand<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return await handler.HandleAsync(command, cancellationToken);
        }

        public async Task<TResult> SendQuery<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.HandleAsync(query, cancellationToken);
        }
    }
}
