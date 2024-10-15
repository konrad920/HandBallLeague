using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Players
{
    public class AddPLayerRequest : IRequest<AddPlayerResponse>
    {
        public int PlayerTeamId { get; set; }

        public string PlayerName { get; set; }

        public string PlayerSurname { get; set; }

        public string PlayerPosition { get; set; }

        public int PlayerAge { get; set; }

        public float PlayerSalary { get; set; }
    }
}
