using System;
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

            var playerOne = matchService.GetPlayerOne(match);
            var playerTwo = matchService.GetPlayerTwo(match);
            var winner = matchResultService.DetermineWinner(match);
            var turn = matchService.GetNextTurn(match);
            var isFinished = matchService.IsFinished(match);

            var matchViewModel = new MatchViewModel
            {
                MatchId = match.MatchId,
                PlayerOne = playerOne != null ? new PlayerViewModel
                {
                    PlayerId = playerOne.PlayerId,
                    Name = playerOne.Name,
                    MatchId = playerOne.MatchId,
                    Symbol = playerOne.Symbol
                } : null,
                PlayerTwo = playerTwo != null ? new PlayerViewModel
                {
                    PlayerId = playerTwo.PlayerId,
                    Name = playerTwo.Name,
                    MatchId = playerTwo.MatchId,
                    Symbol = playerTwo.Symbol
                } : null,
                WinnerId = winner?.PlayerId,
                PlayerTurnId = turn?.PlayerId,
                IsFinished = isFinished
            };

            return Ok(matchViewModel);
        }
    }
}
