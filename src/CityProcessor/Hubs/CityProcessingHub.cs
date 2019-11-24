using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CityProcessor.Hubs
{
    public class CityProcessingHub : Hub<ICityProcessingClient>
    {
        
    }
}