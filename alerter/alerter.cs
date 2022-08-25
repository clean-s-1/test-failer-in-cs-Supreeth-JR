using System;
using System.Diagnostics;
using alerter;
using Moq;

namespace AlerterSpace
{
    class Alerter
    {
        static int alertFailureCount = 0;
        static int networkAlertStub(float celcius)
        {
            PrintOutput(celcius);
            if (celcius > 37)
            {
                return 500;
            }
            return 200;
        }
        static void alertInCelcius(float farenheit)
        {
            float celcius = ConvertToCelcius(farenheit);
            int returnCode = networkAlertStub(celcius);
            if (returnCode != 200)
            {
                alertFailureCount += 1;
            }
        }
        static float ConvertToCelcius(float farenheit)
        {
            float celcius = (farenheit - 32) * 5 / 9;
            return celcius;
        }

        static void PrintOutput(float celcius)
        {
            Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);
        }
        static void Main(string[] args)
        {
            Mock<INetworkStubs> stubs = new Mock<INetworkStubs>();

            stubs.Setup(x => x.NetworkAlert(It.IsAny<float>())).Returns(500);

            alertInCelcius(400.5f);
            alertInCelcius(303.6f);
            alertInCelcius(95);
            Debug.Assert(alertFailureCount == 2);

            int networkAlertStubResult = stubs.Object.NetworkAlert(33.0f);
            Debug.Assert(networkAlertStubResult == 200);
            networkAlertStubResult = stubs.Object.NetworkAlert(38.0f); 
            Debug.Assert(networkAlertStubResult == 500);

            double clecius = ConvertToCelcius(303.6f);
            Debug.Assert(Math.Round(clecius,1)  == 150.9);
        }
    }
}
