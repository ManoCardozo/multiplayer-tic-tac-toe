using System;
using TicTacToe.Core.Domain.Enum;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class PlayerViewData
    {
        public Guid MatchId { get; set; }
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public BoardSymbol Symbol { get; set; }
    }
}
