// =================================
//      (C) Winglett 2020
// =================================

using UnityEngine;

namespace Winglett.DRM
{
    public class SteamAchievements : DRMAchievements
    {
        public override void Unlock(string id)
        {
            Debug.Log("Achievement Unlocked");
        }

        public override void Clear(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}