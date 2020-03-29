using System;
using System.Collections.Generic;
using TicTacToe.Core.Domain.Enum;

namespace TicTacToe.Core.Domain.Entities
{
    public class Player
    {
        public Player()
        {
            FilledBoxes = new List<Box>();
            Plays = new List<Play>();
        }

        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public BoardSymbol Symbol { get; set; }
        public Guid MatchId { get; set; }

        public virtual Match Match { get; set; }
        public virtual List<Box> FilledBoxes { get; set; }
        public virtual List<Play> Plays { get; set; }
    }
}