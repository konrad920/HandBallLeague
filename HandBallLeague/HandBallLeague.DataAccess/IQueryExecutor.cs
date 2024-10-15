using HandBallLeague.DataAccess.CQRS.Queries;

namespace HandBallLeague.DataAccess
{
    public interface IQueryExecutor
    {
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
