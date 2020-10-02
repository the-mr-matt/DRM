// =================================
//      (C) Winglett 2020
// =================================

using System.Threading.Tasks;

namespace Winglett.DRM
{
    public abstract class DRMInitialize : DRMComponent
    {
        public delegate void EventHandler();
        public abstract event EventHandler OnConnected;

        public abstract Task Connect();
        public abstract void Disconnect();
        public abstract void Update();
    }
}