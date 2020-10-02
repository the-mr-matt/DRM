// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public abstract class DRMRichPresence : DRMComponent
    {
        public abstract void SetState(string state);
        public abstract void SetAdditionalParams(string key, string value);
    }
}