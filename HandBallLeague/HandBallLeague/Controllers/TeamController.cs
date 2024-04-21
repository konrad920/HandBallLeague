using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HandBallLeague.Controllers
{
    [ApiController]
    [Route("Controllers")]
    public class TeamController : ControllerBase
    {
        private readonly IRepository<TeamDB> _teamRepository;
        public TeamController(IRepository<TeamDB> teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<TeamDB> GetTeams()
        {
            return _teamRepository.GetAll();
        }
    }
}
