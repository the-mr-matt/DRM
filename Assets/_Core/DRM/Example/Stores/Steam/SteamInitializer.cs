// =================================
//      (C) Winglett 2020
// =================================

using System.Threading.Tasks;
using UnityEngine;

namespace Winglett.DRM
{
    public class SteamInitializer : DRMInitialize
    {
        public override event EventHandler OnConnected;

        public override async Task Connect()
        {
            Debug.Log("Connecting to Steam");

            await Task.Delay(1000);

            OnConnected?.Invoke();
        }

        public override void Disconnect() => Debug.Log("Disconnected from steam");

        public override void Update()
        {
            
        }
    }
}