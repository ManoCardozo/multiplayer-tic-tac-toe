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
        private readonly IMatchResultService matchResultService;

        public MatchController(
            IMatchService matchService,
            IMatchResultService matchResultService)
        {
            this.matchService = matchService;
            this.matchResultService = matchResultService;
        }

        [HttpGet]
        public ActionResult<MatchViewModel> Get(Guid matchId)
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

            var winner = matchResultService.DetermineWinner(match);
            var turn = matchService.GetNextTurn(match);

            var matchViewModel = new MatchViewModel
            {
                MatchId = match.MatchId,
                Player1 = player1 != null ? new PlayerViewModel
                {
                    PlayerId = player1.PlayerId,
                    Name = player1.Name,
                    MatchId = player1.MatchId,
                    Symbol = player1.Symbol
                } : null,
                Player2 = player2 != null ? new PlayerViewModel
                {
                    PlayerId = player2.PlayerId,
                    Name = player2.Name,
                    MatchId = player2.MatchId,
                    Symbol = player2.Symbol
                } : null,
                WinnerId = winner?.PlayerId,
                PlayerTurnId = turn?.PlayerId
            };

            return Ok(matchViewModel);
        }
    }
}
