// =================================
//      (C) Winglett 2020
// =================================

using UnityEngine;

namespace Winglett.DRM
{
    public class SteamInitializer : DRMInitialize
    {
        public override void Connect() => Debug.Log("Connecting to steam");
        public override void Disconnect() => Debug.Log("Disconnected from steam");
        public override void OnConnect() => Debug.Log("Successfully connected to steam");

        public override void Update()
        {
            
        }
    }
}