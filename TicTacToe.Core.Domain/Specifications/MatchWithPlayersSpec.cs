using System;
using System.Linq.Expressions;
using TicTacToe.Core.Domain.Entities;
using TicTacToe.Core.Domain.FetchStrategy;
using TicTacToe.Core.Domain.FetchStrategy.Interfaces;
using TicTacToe.Core.Domain.Specifications.Interfaces;

namespace TicTacToe.Core.Domain.Specifications
{
    public class MatchWithPlayersSpec : ISpecification<Match>
    {
        public Expression<Func<Match, bool>> Criteria { get; private set; }

        public IFetchStrategy<Match> FetchStrategy { get; set; }

        public MatchWithPlayersSpec()
        {
            Criteria = a => a.MatchId != null;

            FetchStrategy = new GenericFetchStrategy<Match>().Include(a => a.Players);
        }
    }
}
