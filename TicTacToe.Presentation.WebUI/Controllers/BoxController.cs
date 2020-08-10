using System;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Presentation.WebUI.Models;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Infrastructure.Repository.UnitOfWork;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Presentation.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BoxController : ControllerBase
    {
        private readonly IBoxService boxService;
        private readonly IPlayerService playerService;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public BoxController(
            IBoxService boxService,
            IPlayerService playerService,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.boxService = boxService;
            this.playerService = playerService;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        [HttpPut]
        public ActionResult<BoxViewModel> Mark(Guid playerId, Guid boxId)
        {
            var box = boxService.Get(boxId);
            var player = playerService.Get(playerId);

            if (box == null || player == null)
            {
                return NotFound();
            }

            if (box.MarkedBy == null)
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    box.MarkedById = player.PlayerId;

                    //Add play to match history
                    box.Board.Match.Plays.Add(new Play {
                        PlayerId = player.PlayerId
                    });

                    unitOfWork.Commit();
                }
            }

            return Ok(new BoxViewModel
            {
                BoxId = box.BoxId
            });
        }
    }
}
