using System;
using System.Collections.Generic;
using System.Text;

namespace AMPQMessages.Messages
{
    public class CityCreatedMessage
    {
        public int SolutionOneCityId { get; set; }

        public string Name { get; set; }

        public DateTime FoundationDate { get; set; }
    }
}
