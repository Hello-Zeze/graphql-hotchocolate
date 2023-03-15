using Microsoft.AspNetCore.SignalR;

namespace PhotonBeam.Hubs
{
    public class UserHub: Hub
    {
        public static int TotalViews { get; set; } = 0;

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            // Broadcast to connected clients
            await Clients.All.SendAsync("updatedTotalViews", TotalViews);
        }
    }
}
