// =================================
//      (C) Winglett 2020
// =================================

using UnityEngine;

namespace Winglett.DRM
{
    public class Store_GOG : Store
    {
        public override string ID => "GOG";

        public Store_GOG()
        {
        }

        protected override DRMInitialize CreateInitializer() => new GOGInitialize();
    }
}