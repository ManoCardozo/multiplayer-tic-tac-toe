using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Core.Domain.Enum;
using TicTacToe.Core.Domain.Entities;
using TicTacToe.Infrastructure.Repository;
using TicTacToe.Presentation.WebUI.Models;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Infrastructure.Repository.UnitOfWork;

namespace TicTacToe.Presentation.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PlayerController : ControllerBase
    {
        private readonly IMatchService matchService;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IGenericRepository repository;

        public PlayerController(
            IMatchService matchService, 
            IUnitOfWorkFactory unitOfWorkFactory,
            IGenericRepository repository)
        {
            this.matchService = matchService;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult<PlayerViewModel> InitPlayer(string playerName)
        {
            var match = matchService.GetOpen();

            //Create a new player
            var playerCount = (match?.Players?.Count() ?? 0) + 1;

            playerName = string.IsNullOrEmpty(playerName)
                ? $"Player {playerCount}" 
                : playerName;

            var newPlayer = new Player
            {
                Name = playerName,
                Symbol = playerCount == 1
                    ? BoardSymbol.Cross
                    : BoardSymbol.Circle
            };

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                if (match == null)
                {
                    match = new Match(2);
                    repository.Add(match);
                }

                //Add new player to the match
                newPlayer.MatchId = match.MatchId;

                repository.Add(newPlayer);
                unitOfWork.Commit();
            }

            var playerViewModel = new PlayerViewModel
            {
                PlayerId = newPlayer.PlayerId,
                MatchId = newPlayer.Match.MatchId
            };

            return Ok(playerViewModel);
        }
    }
}
