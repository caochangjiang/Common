namespace Common.Configurations
{
    public class CommonConfiguration
    {
        public static CommonConfiguration Instance { get; private set; }

        public static CommonConfiguration Create()
        {
            Instance = new CommonConfiguration();
            return Instance;
        }

    }
}
