using HandBallLeague.DataAccess.CQRS.Queries;

namespace HandBallLeague.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly HandBallLeagueContext context;

        public QueryExecutor(HandBallLeagueContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
