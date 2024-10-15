using HandBallLeague.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace HandBallLeague.DataAccess
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly HandBallLeagueContext context;

        public CommandExecutor(HandBallLeagueContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParametr, TResult>(CommandBase<TParametr, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
