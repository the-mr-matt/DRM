// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public class Store_Steam : Store
    {
        #region ----PROPERTIES----
        public override string ID => "Steam";
        public override string UserID => "STEAM USER ID";
        #endregion

        public Store_Steam()
        {
            RegisterComponent<SteamAchievements>();
        }

        protected override DRMInitialize CreateInitializer() => new SteamInitializer();
    }
}