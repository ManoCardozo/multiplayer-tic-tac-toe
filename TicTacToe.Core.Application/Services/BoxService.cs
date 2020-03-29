using System;
using TicTacToe.Core.Domain.Entities;
using TicTacToe.Infrastructure.Repository;
using TicTacToe.Core.Application.Interfaces;

namespace TicTacToe.Core.Application.Services
{
    public class BoxService : IBoxService
    {
        private readonly IGenericRepository repository;

        public BoxService(IGenericRepository repository)
        {
            this.repository = repository;
        }
        public Box Get(Guid boxId)
        {
            return repository.Get<Box>(boxId);
        }
    }
}