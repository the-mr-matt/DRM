// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public abstract class DRMInitialize : DRMComponent
    {
        public abstract void Connect();
        public abstract void OnConnect();

        public abstract void Disconnect();
        public abstract void Update();
    }
}