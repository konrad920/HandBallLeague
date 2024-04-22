using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
{
    public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesRequest, GetAllCoachesResponse>
    {
        private readonly IRepository<CoachDB> repository;

        public GetAllCoachesHandler(IRepository<CoachDB> repository)
        {
            this.repository = repository;
        }
        public Task<GetAllCoachesResponse> Handle(GetAllCoachesRequest request, CancellationToken cancellationToken)
        {
            var coaches = this.repository.GetAll();
            var coachesDomain = coaches.Select(x => new Coach()
            {
                Id = x.Id,
                Name = x.NameOfCoach,
                Age = x.AgeOfCoach
            });

            var response = new GetAllCoachesResponse()
            {
                Data = coachesDomain.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
