// =================================
//      (C) Winglett 2020
// =================================

using UnityEngine;

namespace Winglett.DRM.Examples
{
    public class TestAchievements : MonoBehaviour
    {
        private void Start()
        {
            DRMManager.Store.GetComponent<DRMAchievements>()?.Unlock("");
        }
    }
}