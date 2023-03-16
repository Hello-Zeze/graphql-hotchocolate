using Microsoft.AspNetCore.SignalR;

namespace PhotonBeam.Hubs
{
    public class UserHub: Hub
    {
        public static int TotalViews { get; set; } = 0;
        public static int TotalUsers { get; set; } = 0;

        public override async Task OnConnectedAsync()
        {
            TotalUsers++;
            await Clients.All.SendAsync("updatedTotalUsers", TotalUsers);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUsers--;
            await Clients.All.SendAsync("updatedTotalUsers", TotalUsers);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            // Broadcast to connected clients
            await Clients.All.SendAsync("updatedTotalViews", TotalViews);
        }
    }
}
