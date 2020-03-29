using System;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Core.Domain.Entities;
using TicTacToe.Infrastructure.Repository;

namespace TicTacToe.Core.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IGenericRepository repository;

        public PlayerService(IGenericRepository repository)
        {
            this.repository = repository;
        }

        public Player Get(Guid playerId)
        {
            return repository.Get<Player>(playerId);
        }
    }
}
