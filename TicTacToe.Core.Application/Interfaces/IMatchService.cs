using System;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Core.Application.Interfaces
{
    public interface IMatchService
    {
        Match Get(Guid matchId);
        Match GetOpen();
        Player GetNextTurn(Match match);
        Player GetPlayerOne(Match match);
        Player GetPlayerTwo(Match match);
        bool IsFinished(Match match);
    }
}