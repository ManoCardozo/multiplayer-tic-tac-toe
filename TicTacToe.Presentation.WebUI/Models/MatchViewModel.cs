using System;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class MatchViewModel
    {
        public Guid MatchId { get; set; }
        public PlayerViewModel PlayerOne { get; set; }
        public PlayerViewModel PlayerTwo { get; set; }
        public Guid? WinnerId { get; set; }
        public Guid? PlayerTurnId { get; set; }
        public bool IsFinished { get; set; }
    }
}
