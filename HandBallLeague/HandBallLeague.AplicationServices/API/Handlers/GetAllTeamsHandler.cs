using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
{
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsRequest, GetAllTeamsResponse>
    {
        private readonly IRepository<TeamDB> repository;
        private readonly IMapper mapper;

        public GetAllTeamsHandler(IRepository<TeamDB> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetAllTeamsResponse> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            var teams = await this.repository.GetAll();
            var mappedTeams = this.mapper.Map<List<Team>>(teams);
            var response = new GetAllTeamsResponse()
            {
                Data = mappedTeams
            };

            return response;
        }
    }
}
