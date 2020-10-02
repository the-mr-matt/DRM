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
            DRM.Store.GetComponent<DRMAchievements>()?.Unlock("");
        }
    }
}