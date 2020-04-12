using System;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class MatchViewModel
    {
        public Guid MatchId { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public Guid? WinnerId { get; set; }
    }
}
