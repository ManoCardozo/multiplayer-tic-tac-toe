using System.Linq;
using System.Collections.Generic;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Core.Domain.Entities;

namespace TicTacToe.Core.Application.Services
{
    public class MatchResultService : IMatchResultService
    {
        private readonly List<List<int>> WinningCombinations = new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 4, 7 },
            new List<int> { 1, 5, 9 },
            new List<int> { 2, 5, 8 },
            new List<int> { 3, 5, 7 },
            new List<int> { 3, 6, 9 },
            new List<int> { 4, 5, 6 },
            new List<int> { 7, 8, 9 }
        };

        public Player DetermineWinner(Match match)
        {
            var boxes = match?.Board?.Boxes;

            if (boxes != null)
            {
                foreach (var player in match?.Players)
                {
                    var markedPositions = boxes
                        .Where(b => b.MarkedById == player?.PlayerId)
                        .Select(s => s.BoxPosition)
                        .ToList();

                    var isWinningCombination = WinningCombinations
                        .Any(w => w.All(a => markedPositions.Contains(a)));

                    if (isWinningCombination)
                    {
                        return player;
                    }
                }
            }

            return null;
        }
    }
}
