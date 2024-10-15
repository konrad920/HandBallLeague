using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Matches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Matches
{
    public class GetMatchByIdHandler : IRequestHandler<GetMatchByIDRequest, GetMatchByIDResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetMatchByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetMatchByIDResponse> Handle(GetMatchByIDRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchByIdQuery()
            {
                MatchId = request.Id
            };
            var match = await this.queryExecutor.Execute(query);
            var mappedMatch = this.mapper.Map<Match>(match);
            var response = new GetMatchByIDResponse()
            {
                Data = mappedMatch
            };
            return response;
        }
    }
}
