using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Teams;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Teams
{
    public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdRequest, GetTeamByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetTeamByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetTeamByIdResponse> Handle(GetTeamByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamByIdQuery()
            {
                TeamId = request.Id
            };
            var team = await this.queryExecutor.Execute(query);
            var mappedTeam = this.mapper.Map<Team>(team);
            var response = new GetTeamByIdResponse()
            {
                Data = mappedTeam
            };
            return response;
        }
    }
}
