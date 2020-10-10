// =================================
//      (C) Winglett 2020
// =================================

using System.Threading.Tasks;

namespace Winglett.DRM
{
    public abstract class DRMComponent
    {
        public async virtual Task OnInitialize() { }
        public virtual void Dispose() { }
    }
}