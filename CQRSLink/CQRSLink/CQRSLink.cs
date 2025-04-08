using CQRSLink.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;


namespace CQRSLink.CQRSLink
{
    public class CQRSLink : ICQRSLink
    {
        private readonly IServiceProvider _serviceProvider;
        
        [DebuggerStepThrough]
        public CQRSLink(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [DebuggerStepThrough]
        public async Task<TResult> SendCommand<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return await handler.HandleAsync(command, cancellationToken);
        }

        [DebuggerStepThrough]
        public async Task<TResult> SendCommand<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        {
            var commandType = command.GetType();
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult));
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);
            return await handler.HandleAsync((dynamic)command, cancellationToken);
        }

        [DebuggerStepThrough]
        public async Task<TResult> SendQuery<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.HandleAsync(query, cancellationToken);
        }

        [DebuggerStepThrough]
        public async Task<TResult> SendQuery<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            var queryType = query.GetType();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);
            return await handler.HandleAsync((dynamic)query, cancellationToken);
        }
    }
}
