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

        public GetAllTeamsHandler(IRepository<TeamDB> repository)
        {
            this.repository = repository;
        }
        public Task<GetAllTeamsResponse> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            var teams = this.repository.GetAll();
            var teamsDomain = teams.Select(x => new Team()
            {
                Id = x.Id,
                NameOfTeam = x.NameOfTeam,
                CityOfTeam = x.CityOfTeam
            });

            var response = new GetAllTeamsResponse()
            {
                Data = teamsDomain.ToList(),
            };

            return Task.FromResult(response);
        }
    }
}
