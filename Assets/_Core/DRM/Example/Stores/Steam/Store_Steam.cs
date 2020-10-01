// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public class Store_Steam : Store
    {
        #region ----PROPERTIES----
        public override string ID => "Steam";
        #endregion

        public Store_Steam()
        {
            RegisterComponent(new SteamAchievements());
        }

        protected override DRMInitialize CreateInitializer() => new SteamInitializer();
    }
}