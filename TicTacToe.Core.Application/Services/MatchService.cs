﻿using System;
using System.Linq;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Core.Domain.Entities;
using TicTacToe.Core.Domain.Specifications;
using TicTacToe.Infrastructure.Repository;

namespace TicTacToe.Core.Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IGenericRepository repository;

        public MatchService(IGenericRepository repository)
        {
            this.repository = repository;
        }

        public Match Get(Guid matchId)
        {
            return repository.Get<Match>(matchId);
        }

        public Match GetOpen()
        {
            var match = repository
                .GetAll(new MatchWithPlayersSpec())
                .FirstOrDefault(m => m.Players.Count < m.MaxPlayers);

            return match;
        }

        public Player GetNextTurn(Match match)
        {
            var previousTurn = match
                .Plays
                .LastOrDefault();

            //Match is not ready yet
            if (match.Players.Count < match.MaxPlayers)
            {
                return null;
            }

            var nextTurn = match
                .Players
                .FirstOrDefault(p => p.PlayerId != previousTurn?.PlayerId);

            return nextTurn;
        }
    }
}
 