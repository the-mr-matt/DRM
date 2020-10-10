// =================================
//      (C) Winglett 2020
// =================================

using System.Threading.Tasks;
using UnityEngine;

namespace Winglett.DRM
{
    public class SteamAchievements : DRMAchievements
    {
        public override async Task OnInitialize()
        {
            await Task.Delay(4000);
            Debug.Log("Initialize Achievements");
        }

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