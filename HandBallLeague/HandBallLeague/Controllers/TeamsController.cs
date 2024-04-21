using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HandBallLeague.Controllers
{
    [ApiController]
    [Route("Controllers")]
    public class TeamsController : ControllerBase
    {
        private readonly IRepository<TeamDB> _teamRepository;
        public TeamsController(IRepository<TeamDB> teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<TeamDB> GetTeams()
        {
            return _teamRepository.GetAll();
        }

        [HttpGet]
        [Route("teamId")]
        public TeamDB GetTeamById(int teamId)
        {
            return _teamRepository.GetById(teamId);
        }
    }
}
