using System;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Core.Application.Interfaces
{
    public interface IMatchService
    {
        Match Get(Guid matchId);
        Match GetOpen();
        Player GetNextTurn(Match match);
    }
}