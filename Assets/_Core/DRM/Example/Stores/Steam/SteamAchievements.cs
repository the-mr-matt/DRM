// =================================
//      (C) Winglett 2020
// =================================

using UnityEngine;

namespace Winglett.DRM
{
    public class SteamAchievements : DRMAchievements
    {
        public override void Unlock()
        {
            Debug.Log("Achievement Unlocked");
        }

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}