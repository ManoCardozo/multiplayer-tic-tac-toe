using System.Collections.Generic;
using TicTacToe.Core.Domain.Entities;
using TicTacToe.Core.Application.Interfaces;

namespace TicTacToe.Core.Application.Services
{
    public class BoardService : IBoardService
    {
        public BoardService()
        {

        }

        public List<Box> GetDefaultBoard()
        {
            return new List<Box>
            {
                new Box(1),
                new Box(2),
                new Box(3),
                new Box(4),
                new Box(5),
                new Box(6),
                new Box(7),
                new Box(8),
                new Box(9)
            };
        }
    }
}
