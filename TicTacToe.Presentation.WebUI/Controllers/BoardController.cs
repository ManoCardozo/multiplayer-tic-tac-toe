using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Core.Domain.Entities;
using TicTacToe.Infrastructure.Repository;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Infrastructure.Repository.UnitOfWork;
using TicTacToe.Presentation.WebUI.Models;

namespace TicTacToe.Presentation.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BoardController : ControllerBase
    {
        private readonly IMatchService matchService;
        private readonly IBoardService boardService;
        private readonly IGenericRepository repository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public BoardController(
            IMatchService matchService,
            IBoardService boardService,
            IGenericRepository repository,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.matchService = matchService;
            this.boardService = boardService;
            this.repository = repository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        [HttpGet]
        public ActionResult<MatchViewModel> Get(Guid matchId)
        {
            var match = matchService.Get(matchId);

            if (match == null)
            {
                return NotFound();
            }    

            var board = match.Board;

            var boardViewModel = new BoardViewModel();
            
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                if (board == null)
                {
                    board = new Board()
                    {
                        MatchId = match.MatchId,
                        Boxes = boardService.GetDefaultBoard()
                    };

                    repository.Add(board);
                    unitOfWork.Commit();
                }

                var boxes = match.Board?.Boxes;

                boardViewModel = new BoardViewModel
                {
                    Boxes = boxes.Select(b => new BoxViewModel
                    {
                        BoxId = b.BoxId,
                        MarkedBy = b.MarkedBy != null ? new PlayerViewModel
                        {
                            PlayerId = b.MarkedBy.PlayerId,
                            Name = b.MarkedBy.Name,
                            Symbol = b.MarkedBy.Symbol,
                        } : null
                    }).ToList()
                };
            }
                

            return Ok(boardViewModel);
        }
    }
}
