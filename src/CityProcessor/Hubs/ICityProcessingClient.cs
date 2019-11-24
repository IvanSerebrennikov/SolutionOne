using System.Threading.Tasks;

namespace CityProcessor.Hubs
{
    public interface ICityProcessingClient
    {
        Task ReceiveCityProcessingMessage(string text);
    }
}