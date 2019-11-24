using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMQPSharedData.Messages;

namespace CityProcessor.Processor
{
    public interface ICityProcessor
    {
        void ProcessCityCreated(CityCreatedMessage message);
    }
}
