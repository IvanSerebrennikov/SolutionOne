namespace CityProcessor.Hubs
{
    public static class ClientMessages
    {
        public static string CityCreatedMessageConsumed(int sOneId, string name)
        {
            return $"City {sOneId} {name}: Created Message Consumed.";
        }

        public static string CityRegistrationRequested(int sOneId, string name)
        {
            return $"City {sOneId} {name}: Registration Requested.";
        }

        public static string CityRegistrationCompleted(int sOneId, string name, string registryKey)
        {
            return $"City {sOneId} {name}: Registration Completed. RegistryKey: {registryKey}";
        }

        public static string CityRegisteredMessageProduced(int sOneId, string name, string registryKey)
        {
            return $"City {sOneId} {name}: Registered Message Produced. RegistryKey: {registryKey}";
        }
    }
}