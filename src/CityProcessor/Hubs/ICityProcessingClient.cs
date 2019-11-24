using System.Threading.Tasks;
using CityProcessor.Hubs.Messages;

namespace CityProcessor.Hubs
{
    public interface ICityProcessingClient
    {
        Task ReceiveCityProcessingMessage(CityClientMessage message);
    }
}