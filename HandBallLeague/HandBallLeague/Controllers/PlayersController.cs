﻿using HandBallLeague.AplicationServices.API.Domain.Players;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandBallLeague.Controllers
{
    [ApiController]
    [Route("Players")]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlayersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllPlayers([FromQuery] GetAllPlayersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{playerId}")]
        public async Task<IActionResult> GetPlayerById([FromRoute] int playerId)
        {
            var request = new GetPlayerByIdRequest()
            {
                Id = playerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddPlayer([FromBody] AddPLayerRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{playerId}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int playerId)
        {
            var request = new DeletePlayerByIdRequest()
            {
                Id = playerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("playerId")]
        public async Task<IActionResult> EditPlayer([FromBody] EditPlayerByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
