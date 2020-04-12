using System;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class BoxViewModel
    {
        public Guid BoxId { get; set; }
        public PlayerViewModel MarkedBy { get; set; }
    }
}
