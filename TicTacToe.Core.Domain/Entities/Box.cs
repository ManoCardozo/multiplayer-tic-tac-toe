using System;

namespace TicTacToe.Core.Domain.Entities
{
    public class Box
    {
        public Box()
        {

        }

        public Box(int pos)
        {
            this.BoxPosition = pos;
        }

        public Guid BoxId { get; set; }
        public int BoxPosition { get; set; }
        public Guid BoardId { get; set; }
        public Guid MarkedById { get; set; }

        public virtual Board Board { get; set; }
        public virtual Player MarkedBy { get; set; }
    }
}