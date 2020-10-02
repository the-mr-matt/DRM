// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public abstract class DRMAchievements : DRMComponent
    {
        public abstract void Unlock(string id);
        public abstract void Clear(string id);
    }
}