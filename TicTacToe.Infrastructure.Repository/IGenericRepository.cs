using System.Collections.Generic;
using TicTacToe.Core.Domain.Specifications.Interfaces;

namespace TicTacToe.Infrastructure.Repository
{
	public interface IGenericRepository
	{
		T Get<T>(object id) where T : class;
		IEnumerable<T> GetAll<T>() where T : class;
		IEnumerable<T> GetAll<T>(ISpecification<T> specification) where T : class;
		void Add<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
	}
}
