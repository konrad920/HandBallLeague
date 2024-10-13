using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
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
            var teams = await this.queryExecutor.Execute(query);
            var mappedTeams = this.mapper.Map<List<Team>>(teams);
            var response = new GetAllTeamsResponse()
            {
                Data = mappedTeams
            };

            return response;
        }
    }
}
