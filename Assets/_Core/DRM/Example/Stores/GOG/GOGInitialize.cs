// =================================
//      (C) Winglett 2020
// =================================

using System.Threading.Tasks;
using UnityEngine;

namespace Winglett.DRM
{
    public class GOGInitialize : DRMInitialize
    {
        public override event EventHandler OnConnected;

        public override async Task Connect()
        {
            Debug.Log("Connecting to GOG");

            await Task.Delay(1000);

            OnConnected?.Invoke();
        }

        public override void Disconnect() => Debug.Log("Disconnected from GOG");

        public override void Update()
        {

        }
    }
}