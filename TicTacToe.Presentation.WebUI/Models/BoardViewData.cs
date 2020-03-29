using System;
using System.Collections.Generic;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class BoardViewData
    {
        public BoardViewData()
        {
            Boxes = new List<BoxViewData>();
        }

        public Guid BoardId { get; set; }
        public List<BoxViewData> Boxes { get; set; }
    }
}
