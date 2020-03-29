using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Presentation.WebUI.Models;
using TicTacToe.Core.Application.Interfaces;

namespace TicTacToe.Presentation.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService matchService;

        public MatchController(
            IMatchService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet]
        public ActionResult<MatchViewData> Get(Guid matchId)
        {
            var match = matchService.Get(matchId);

            if (match == null)
            {
                return NotFound();
            }

            var players = match?.Players;

            var player1 = players?
                .Skip(0)?
                .Take(1)?
                .FirstOrDefault();

            var player2 = players?
                .Skip(1)?
                .Take(1)?
                .FirstOrDefault();

            var matchViewData = new MatchViewData
            {
                MatchId = match.MatchId,
                Player1Name = player1?.Name,
                Player2Name = player2?.Name,
            };

            return Ok(matchViewData);
        }
    }
}
