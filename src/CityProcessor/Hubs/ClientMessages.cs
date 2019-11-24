namespace CityProcessor.Hubs
{
    public static class ClientMessages
    {
        public static string GetCityCreatedMessageConsumed(int sOneId, string name)
        {
            return $"City {sOneId} {name}: Created Message Consumed.";
        }

        public static string GetCityRegistrationRequested(int sOneId, string name)
        {
            return $"City {sOneId} {name}: Registration Requested.";
        }

        public static string GetCityRegistrationCompleted(int sOneId, string name, string registerKey)
        {
            return $"City {sOneId} {name}: Registration Completed. RegisterKey: {registerKey}";
        }

        public static string GetCityRegisteredMessageProduced(int sOneId, string name, string registerKey)
        {
            return $"City {sOneId} {name}: Registered Message Produced. RegisterKey: {registerKey}";
        }
    }
}