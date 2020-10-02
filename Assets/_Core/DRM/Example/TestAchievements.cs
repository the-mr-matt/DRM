// =================================
//      (C) Winglett 2020
// =================================

using UnityEngine;

namespace Winglett.DRM.Examples
{
    public class TestAchievements : MonoBehaviour
    {
        private void OnEnable() => DRMManager.OnConnected += DRMManager_OnConnected;
        private void OnDisable() => DRMManager.OnConnected -= DRMManager_OnConnected;

        private void DRMManager_OnConnected()
        {
            DRMManager.Store.GetComponent<DRMAchievements>()?.Unlock("");
        }
    }
}