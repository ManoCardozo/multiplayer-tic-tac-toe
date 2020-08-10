using System;
using System.Linq;
using System.Linq.Expressions;

namespace TicTacToe.Core.Domain.Extensions
{
    public static class ExpressionExtensions
    {
        public static string ToPropertyName<T>(this Expression<Func<T, object>> @this)
        {
            var exclude = new[] { "First()", "Single()" };
            var propertyString = @this.ToString();
            if (propertyString.Contains("Convert("))
                propertyString = propertyString.Replace("Convert(", "").TrimEnd(')');
            var path = propertyString.Split('.').Skip(1).Where(s => exclude.All(ex => ex != s));
            return string.Join(".", path);
        }
    }
}
