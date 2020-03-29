using System;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Core.Application.Interfaces
{
    public interface IBoxService
    {
        Box Get(Guid boxId);
    }
}