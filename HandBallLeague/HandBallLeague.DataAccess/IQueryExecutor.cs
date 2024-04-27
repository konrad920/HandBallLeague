using HandBallLeague.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandBallLeague.DataAccess
{
    public interface IQueryExecutor
    {
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
