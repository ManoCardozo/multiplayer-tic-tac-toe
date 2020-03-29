using System;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Core.Application.Interfaces
{
    public interface IPlayerService
    {
        Player Get(Guid playerId);
    }
}