namespace alerter
{
    public class NetworkStubs : INetworkStubs
    {
        public int NetworkAlert(float celcius)
        {
            if (celcius > 37.0f)
            {
                return 500;
            }
            return 200;
        }
    }
}
