// =================================
//      (C) Winglett 2020
// =================================

using UnityEngine;

namespace Winglett.DRM
{
    public class GOGInitialize : DRMInitialize
    {
        public override void Connect() => Debug.Log("Connecting to GOG");
        public override void Disconnect() => Debug.Log("Disconnected from GOG");
        public override void OnConnect() => Debug.Log("Successfully connected to GOG");

        public override void Update()
        {

        }
    }
}