using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TicTacToe.Core.Domain.FetchStrategy.Interfaces;

namespace TicTacToe.Core.Domain.Specifications.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        IFetchStrategy<T> FetchStrategy { get; set; }
    }
}
