using System;

namespace AMQPSharedData.Messages
{
    public class CityCreatedMessage
    {
        public int SolutionOneCityId { get; set; }

        public string Name { get; set; }

        public DateTime FoundationDate { get; set; }
    }
}
