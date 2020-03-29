using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TicTacToe.Core.Domain.Extensions;
using TicTacToe.Core.Domain.FetchStrategy.Interfaces;

namespace TicTacToe.Core.Domain.FetchStrategy
{
    public class GenericFetchStrategy<T> : IFetchStrategy<T>
    {
        private readonly IList<string> properties;

        public GenericFetchStrategy()
        {
            properties = new List<string>();
        }

        #region IFetchStrategy<T> Members

        public IEnumerable<string> IncludePaths
        {
            get { return properties; }
        }

        public IFetchStrategy<T> Include(Expression<Func<T, object>> path)
        {
            var propertyName = path.ToPropertyName();
            properties.Add(propertyName);
            return this;
        }

        public IFetchStrategy<T> Include(string path)
        {
            properties.Add(path);
            return this;
        }

        public override string ToString()
        {
            return properties.Count > 0 ? string.Join(",", properties) : this.GetType().FullName;
        }
        #endregion

    }
}
