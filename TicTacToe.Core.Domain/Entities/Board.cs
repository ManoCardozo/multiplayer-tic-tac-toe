using System;
using System.Collections.Generic;

namespace TicTacToe.Core.Domain.Entities
{
    public class Board
    {
        public Board()
        {
            Boxes = new List<Box>();
        }

        public Guid BoardId { get; set; }
        public Guid MatchId { get; set; }


        public virtual Match Match { get; set; }
        public virtual List<Box> Boxes { get; set; }
    }
}
