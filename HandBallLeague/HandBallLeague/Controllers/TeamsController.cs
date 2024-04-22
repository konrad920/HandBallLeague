﻿using HandBallLeague.AplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandBallLeague.Controllers
{
    [ApiController]
    [Route("Teams")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeamsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllTeams([FromQuery] GetAllTeamsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
