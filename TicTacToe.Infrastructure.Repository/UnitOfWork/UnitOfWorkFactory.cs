using TicTacToe.Infrastructure.Persistence;

namespace TicTacToe.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ITicTacToeContext ticTacToeContext;
        public UnitOfWorkFactory(ITicTacToeContext ticTacToeContext)
        {
            this.ticTacToeContext = ticTacToeContext;
        }
        public IUnitOfWork Create()
        {
            return new UnitOfWork(ticTacToeContext);
        }
    }
}
