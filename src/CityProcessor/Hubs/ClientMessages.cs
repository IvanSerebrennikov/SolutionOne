﻿namespace CityProcessor.Hubs
{
    public static class ClientMessages
    {
        public static string CityCreatedMessageConsumed(int sOneId, string name)
        {
            return $"{CityInfoPart(sOneId, name)}: Created Message Consumed.";
        }

        public static string CityRegistrationRequested(int sOneId, string name)
        {
            return $"{CityInfoPart(sOneId, name)}: Registration Requested.";
        }

        public static string CityRegistrationCompleted(int sOneId, string name, string registryKey)
        {
            return $"{CityInfoPart(sOneId, name)}: Registration Completed. RegistryKey: {registryKey}";
        }

        public static string CityRegisteredMessageProduced(int sOneId, string name, string registryKey)
        {
            return $"{CityInfoPart(sOneId, name)}: Registered Message Produced. RegistryKey: {registryKey}";
        }

        private static string CityInfoPart(int sOneId, string name)
        {
            return $"City [Id: {sOneId}, Name: '{name}']";
        }
    }
}