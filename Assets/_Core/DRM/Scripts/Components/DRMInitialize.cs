// =================================
//      (C) Winglett 2020
// =================================

using System.Threading.Tasks;

namespace Winglett.DRM
{
    public abstract class DRMInitialize : DRMComponent
    {
        public abstract Task Connect();
        public abstract void Disconnect();
        public abstract void Update();
    }
}