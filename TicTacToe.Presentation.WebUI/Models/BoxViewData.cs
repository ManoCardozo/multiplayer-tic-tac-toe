using System;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class BoxViewData
    {
        public Guid BoxId { get; set; }
        public PlayerViewData MarkedBy { get; set; }
    }
}
