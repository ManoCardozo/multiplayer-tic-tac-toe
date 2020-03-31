using System;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Presentation.WebUI.Models;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Infrastructure.Repository.UnitOfWork;

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
        public ActionResult<BoxViewData> Mark(Guid playerId, Guid boxId)
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
                    //Mark box by populating marked by person
                    box.MarkedById = player.PlayerId;

                    unitOfWork.Commit();
                }
            }

            return Ok(new BoxViewData
            {
                BoxId = box.BoxId
            });
        }
    }
}
