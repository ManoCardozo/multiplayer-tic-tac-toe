using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Domain.FetchStrategy.Interfaces;
using TicTacToe.Core.Domain.Specifications.Interfaces;
using TicTacToe.Infrastructure.Persistence;

namespace TicTacToe.Infrastructure.Repository
{
	public class GenericRepository : IGenericRepository, IDisposable
	{
		private readonly ITicTacToeContext context;

		public GenericRepository(ITicTacToeContext context)
		{
			this.context = context;
		}

		public void Dispose()
		{
			if (context != null)
				context.Dispose();
		}

		public virtual T Get<T>(object id) where T : class
		{
			return context.Set<T>().Find(id);
		}

		public virtual IEnumerable<T> GetAll<T>() where T : class
		{
			return context.Set<T>().ToList();
		}

		public virtual IEnumerable<T> GetAll<T>(ISpecification<T> specification) where T : class
		{
			return GetQuery(specification.FetchStrategy).Where(specification.Criteria).ToList();
		}

		public virtual void Add<T>(T entity) where T : class
		{
			context.Set<T>().Add(entity);
		}

		public virtual void Update<T>(T entity) where T : class
		{
			context.Set<T>().Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete<T>(T entity) where T : class
		{
			if (context.Entry(entity).State == EntityState.Detached)
			{
				context.Set<T>().Attach(entity);
			}
			context.Set<T>().Remove(entity);
		}

		private IQueryable<T> GetQuery<T>(IFetchStrategy<T> fetchStrategy) where T : class
		{
			var query = context.Set<T>().AsQueryable();

			if (fetchStrategy == null)
			{
				return query;
			}

			return fetchStrategy.IncludePaths.Aggregate(query, (current, includePath) => current.Include(includePath));
		}
	}
}
