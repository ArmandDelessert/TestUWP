using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;

namespace TestUWP.GetInfos
{
    public static class InfoNetwork
    {
        /// <summary>
        /// This class provides information about the network.
        /// 
        /// À ajouter :
        /// - Connexion limitée ?
        /// - Type de co (Ethernet, Wi-Fi, 4G, etc.) ?
        /// </summary>
        /// <returns></returns>
        public static bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public static NetworkConnectivityLevel GetNetworkConnectivityLevel()
        {
            return NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel();
        }

        public static NetworkCostType GetNetworkCostType()
        {
            return NetworkInformation.GetInternetConnectionProfile().GetConnectionCost().NetworkCostType;
        }
    }
}
