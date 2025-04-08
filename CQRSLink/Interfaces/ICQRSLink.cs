namespace CQRSLink.Interfaces
{
    public interface ICQRSLink
    {
        Task<TResult> SendCommand<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>;

        Task<TResult> SendQuery<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>;
    }
}
