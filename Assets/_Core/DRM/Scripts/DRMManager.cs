// =================================
//      (C) Winglett 2020
// =================================

using System;
using System.Linq;
using UnityEngine;

namespace Winglett.DRM
{
    public class DRMManager : MonoBehaviour
    {
        #region ----PROPERTIES----
        public static Store Store { get; private set; }
        #endregion

        #region ----CONFIG----
        [SerializeField] protected string m_EditorStoreFront;
        [SerializeField] protected bool m_SubmitPlayerScoresInEditor;
        #endregion

        #region ----EVENTS----
        public delegate void EventHandler();
        public static event EventHandler OnConnected;
        #endregion

        private async void Awake()
        {
            Store = CreateStore();

            try { await Store.Initializer.Connect(); }
            catch (System.Exception e)
            {
                Debug.LogError($"Unable to connect to DRM \"{Store.ID}\" for reason: {e}");
                Application.Quit();
                return;
            }

            OnConnected?.Invoke();
        }

        private void OnDisable() => Store.Initializer.Disconnect();
        private void Update() => Store.Initializer.Update();

        private Store CreateStore()
        {
            // https://stackoverflow.com/questions/857705/get-all-derived-types-of-a-type
            var storesTypes = (
                    from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetTypes()
                    where assemblyType.IsSubclassOf(typeof(Store))
                    select assemblyType).ToArray();

            // Create an instance of each store type
            Store[] stores = new Store[storesTypes.Length];
            for (int i = 0; i < stores.Length; i++)
            {
                // https://stackoverflow.com/questions/752/how-to-create-a-new-object-instance-from-a-type
                stores[i] = (Store)Activator.CreateInstance(storesTypes[i]);
            }

            // Find the store with correct ID
            string id =
#if UNITY_EDITOR
                m_EditorStoreFront;
#else
                StandaloneStoreFront.GetStandaloneStoreFrontID();
#endif

            if (stores.Any(x => x.ID == id))
            {
                return stores.FirstOrDefault(x => x.ID == id);
            }
            else
            {
                Debug.LogError($"Failed to load store of ID: \"{id}\"");
                return default;
            }
        }
    }
}