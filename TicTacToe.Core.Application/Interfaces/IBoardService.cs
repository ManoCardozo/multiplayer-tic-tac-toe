using System.Collections.Generic;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Core.Application.Interfaces
{
    public interface IBoardService
    {
        List<Box> GetDefaultBoard();
    }
}