using System;
using System.Collections.Generic;

namespace TicTacToe.Presentation.WebUI.Models
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            Boxes = new List<BoxViewModel>();
        }

        public Guid BoardId { get; set; }
        public List<BoxViewModel> Boxes { get; set; }
    }
}
