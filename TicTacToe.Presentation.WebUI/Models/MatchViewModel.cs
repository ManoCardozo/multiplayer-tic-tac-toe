using System;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class MatchViewModel
    {
        public Guid MatchId { get; set; }
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }
        public Guid? WinnerId { get; set; }
        public Guid? PlayerTurnId { get; set;  }
    }
}
