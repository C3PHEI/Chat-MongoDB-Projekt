using Microsoft.AspNetCore.SignalR;

namespace Chat_MongoDB.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string fromUserId, string toUserId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", fromUserId, toUserId, message);
        }
    }

}
