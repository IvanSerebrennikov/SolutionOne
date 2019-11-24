namespace CityProcessor.Hubs.Messages
{
    public class CityClientMessage
    {
        public string HeadText { get; }

        public string ActionText { get; set; }

        public string Color { get; }

        private CityClientMessage(int sOneId, string name, string actionText, string color = null)
        {
            HeadText = $"City [Id: {sOneId}, Name: '{name}']";
            ActionText = actionText;
            Color = color;
        }

        public static CityClientMessage CityCreatedMessageConsumed(int sOneId, string name, 
            string color = null)
        {
            return new CityClientMessage(
                sOneId, name, "Created Message Consumed.", color);
        }

        public static CityClientMessage CityRegistrationRequested(int sOneId, string name, 
            string color = null)
        {
            return new CityClientMessage(
                sOneId, name, "Registration Requested.", color);
        }

        public static CityClientMessage CityRegistrationCompleted(int sOneId, string name, string registryKey,
            string color = null)
        {
            return new CityClientMessage(
                sOneId, name, $"Registration Completed. RegistryKey: {registryKey}.", color);
        }

        public static CityClientMessage CityRegisteredMessageProduced(int sOneId, string name, string registryKey,
            string color = null)
        {
            return new CityClientMessage(
                sOneId, name, $"Registered Message Produced. RegistryKey: {registryKey}.", color);
        }
    }
}