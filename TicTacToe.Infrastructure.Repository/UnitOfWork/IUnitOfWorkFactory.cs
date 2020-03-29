
namespace TicTacToe.Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
