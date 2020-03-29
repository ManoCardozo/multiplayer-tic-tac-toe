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
                new Box(),
                new Box(),
                new Box(),
                new Box(),
                new Box(),
                new Box(),
                new Box(),
                new Box(),
                new Box()
            };
        }
    }
}
