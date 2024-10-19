using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Coaches
{
    public class EditCoachByIdRequest : IRequest<EditCoachByIdResponse>
    {
        public int Id {  get; set; }

        public int EditCoachTeamDBId { get; set; }

        public string EditCoachNameOfCoach { get; set; }

        public string EditCoachSurnameOfCoach { get; set; }

        public int EditCoachAgeOfCoach { get; set; }

        public float EditCoachSalary { get; set; }
    }
}
