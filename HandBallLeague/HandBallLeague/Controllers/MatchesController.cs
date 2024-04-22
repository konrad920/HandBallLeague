﻿using HandBallLeague.AplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandBallLeague.Controllers
{
    [ApiController]
    [Route("Matches")]
    public class MatchesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MatchesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllMatches([FromQuery] GetAllMatchesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
