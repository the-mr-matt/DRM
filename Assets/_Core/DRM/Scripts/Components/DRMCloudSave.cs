// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public abstract class DRMCloudSave : DRMComponent
    {
        /// <summary>
        /// Loads all cloud saved files from the DRM into the game save location.
        /// </summary>
        public abstract void LoadCloudFiles();

        /// <summary>
        /// Uploads local data into the DRM cloud save system
        /// </summary>
        public abstract void SaveCloudFiles();
    }
}