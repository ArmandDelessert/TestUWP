using TestUWP.GetInfos;
using Windows.ApplicationModel.Resources;
using Windows.Networking.Connectivity;

namespace TestUWP.PrintInfos
{
    public class PrintInfoNetwork
    {
        private readonly ResourceLoader rl;

        public PrintInfoNetwork(ResourceLoader rl)
        {
            this.rl = rl;
        }

        public string PrintIfNetworkAvailable()
        {
            return rl.GetString("InfoNetwork_IsAvailable/Text") + InfoNetwork.IsNetworkAvailable();
        }

        public string PrintNetworkConnectivityLevel()
        {
            string baseString = "NetworkConnectivityLevel: ";

            switch (InfoNetwork.GetNetworkConnectivityLevel())
            {
                case NetworkConnectivityLevel.InternetAccess:
                    return baseString + NetworkConnectivityLevel.InternetAccess;
                case NetworkConnectivityLevel.ConstrainedInternetAccess:
                    return baseString + NetworkConnectivityLevel.ConstrainedInternetAccess;
                case NetworkConnectivityLevel.LocalAccess:
                    return baseString + NetworkConnectivityLevel.LocalAccess;
                case NetworkConnectivityLevel.None:
                    return baseString + NetworkConnectivityLevel.None;
            }

            return baseString + InfoNetwork.GetNetworkConnectivityLevel();
        }

        public string PrintNetworkCostType()
        {
            string baseString = "NetworkCostType: ";

            switch (InfoNetwork.GetNetworkCostType())
            {
                case NetworkCostType.Unknown:
                    return baseString + NetworkCostType.Unknown;
                case NetworkCostType.Unrestricted:
                    return baseString + NetworkCostType.Unrestricted;
                case NetworkCostType.Fixed:
                    return baseString + NetworkCostType.Fixed;
                case NetworkCostType.Variable:
                    return baseString + NetworkCostType.Variable;
            }

            return baseString + InfoNetwork.GetNetworkCostType();
        }
    }
}
