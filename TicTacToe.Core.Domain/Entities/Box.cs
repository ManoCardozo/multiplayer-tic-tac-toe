using System;

namespace TicTacToe.Core.Domain.Entities
{
    public class Box
    {
        public Guid BoxId { get; set; }
        public Guid BoardId { get; set; }
        public Guid MarkedById { get; set; }

        public virtual Board Board { get; set; }
        public virtual Player MarkedBy { get; set; }
    }
}