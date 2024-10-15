using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Teams;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.ALL;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Teams
{
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsRequest, GetAllTeamsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllTeamsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllTeamsResponse> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamsQuery();
            var teams = await queryExecutor.Execute(query);
            var mappedTeams = mapper.Map<List<Team>>(teams);
            var response = new GetAllTeamsResponse()
            {
                Data = mappedTeams
            };

            return response;
        }
    }
}
