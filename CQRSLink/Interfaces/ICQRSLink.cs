namespace CQRSLink.Interfaces
{
    public interface ICQRSLink
    {
        // Command
        Task<TResult> SendCommand<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>;
        Task<TResult> SendCommand<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);


        // Query
        Task<TResult> SendQuery<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>;
        Task<TResult> SendQuery<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}
