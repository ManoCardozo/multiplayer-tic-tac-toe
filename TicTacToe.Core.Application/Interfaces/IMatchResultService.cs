using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Core.Application.Interfaces
{
    public interface IMatchResultService
    {
        Player DetermineWinner(Match match);
    }
}
