using UnityEngine;
using Mirror;

namespace Battlecars.Networking
{

    public class BattlecarsNetworkManager : NetworkManager
    {
        /// <summary>
        /// Reference to the battlecars version of the network manager singleton
        /// </summary>
        public static BattlecarsNetworkManager Instance => singleton as BattlecarsNetworkManager;

        /// <summary>
        /// whether or not this NetworkManager is the host
        /// </summary>
        public bool IsHost { get; private set; } = false;

        /// <summary>
        /// Runs when connecting to an online scene as a host
        /// </summary>
        public override void OnStartHost()
        {
            IsHost = true;
        }
    }
}
