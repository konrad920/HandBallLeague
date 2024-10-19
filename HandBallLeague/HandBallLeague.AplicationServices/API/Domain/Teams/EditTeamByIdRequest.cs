using HandBallLeague.DataAccess.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.AplicationServices.API.Domain.Teams
{
    public class EditTeamByIdRequest : IRequest<EditTeamByIdResponse>
    {
        public int Id { get; set; }

        public string EditNameOfTeam { get; set; }

        public string EditCityOfTeam { get; set; }

        public int EditFoundingYear { get; set; }

        public float EditBudgetOfTeam { get; set; }
    }
}
