using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TicTacToe.Core.Domain.FetchStrategy.Interfaces
{
    public interface IFetchStrategy<T>
    {
        IEnumerable<string> IncludePaths { get; }

        IFetchStrategy<T> Include(Expression<Func<T, object>> path);

        IFetchStrategy<T> Include(string path);
    }
}
