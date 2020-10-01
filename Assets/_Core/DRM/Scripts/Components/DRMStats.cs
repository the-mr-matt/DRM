// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public abstract class DRMStats : DRMComponent
    {
        public abstract void SetStat(string statID, int value);
        public abstract void AddStat(string statID);
        public abstract int GetStat(string statID);
    }
}