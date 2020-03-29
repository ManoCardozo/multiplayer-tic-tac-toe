using System;

namespace TicTacToe.Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
