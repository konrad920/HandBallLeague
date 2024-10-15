using HandBallLeague.DataAccess.CQRS.Commands;

namespace HandBallLeague.DataAccess
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParametr, TResult>(CommandBase<TParametr, TResult> command);
    }
}
