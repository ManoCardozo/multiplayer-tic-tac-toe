using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TicTacToe.Presentation.WebUI.Hubs
{
    public class TicTacToeHub : Hub
    {
        /// <summary>
        /// Notify opponent whenever a player joins the match
        /// </summary>
        public async Task JoinMatch(Guid matchId, string playerName)
        {
            var groupName = matchId.ToString();

            await Groups
                .AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients
                .GroupExcept(groupName, Context.ConnectionId)
                .SendAsync("PlayerJoined", $"{playerName} has joined the game.");
        }

        /// <summary>
        /// Notify opponent whenever a player leaves the match
        /// </summary>
        public async Task LeaveMatch(Guid matchId, string playerName)
        {
            var groupName = matchId.ToString();

            await Groups
                .RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients
                .GroupExcept(groupName, Context.ConnectionId)
                .SendAsync("PlayerLeft", $"{playerName} has left the game.");
        }

        /// <summary>
        /// Notify clients that their board needs to be updated
        /// </summary>
        public async Task UpdateBoard(Guid matchId)
        {
            await Clients
                .Group(matchId.ToString())
                .SendAsync("BoardUpdated");
        }
    }
}
