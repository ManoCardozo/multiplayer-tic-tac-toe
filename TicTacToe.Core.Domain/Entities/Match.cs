using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.Core.Domain.Entities
{
    public class Match
    {
        public Match(int maxPlayers)
        {
            MaxPlayers = maxPlayers;
            Players = new List<Player>();
        }

        public Guid MatchId { get; set; }
        public int MaxPlayers { get; set; }

        public virtual Board Board { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}
