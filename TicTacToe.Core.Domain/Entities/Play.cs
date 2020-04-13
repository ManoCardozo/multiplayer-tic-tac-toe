using System;

namespace TicTacToe.Core.Domain.Entities
{
    public class Play
    {
        public Guid PlayId { get; set; }
        public Guid PlayerId { get; set; }

        public virtual Match Match { get; set; }
    }
}
