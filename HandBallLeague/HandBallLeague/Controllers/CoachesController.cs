using HandBallLeague.AplicationServices.API.Domain.Coaches;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandBallLeague.Controllers
{
    [ApiController]
    [Route("Coaches")]
    public class CoachesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CoachesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllCoaches([FromQuery] GetAllCoachesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{coachId}")]
        public async Task<IActionResult> GetCoachById([FromRoute] int coachId)
        {
            var coach = new GetCoachByIdRequest()
            {
                Id = coachId
            };
            var response = await this.mediator.Send(coach);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCoach([FromBody] AddCoachRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
