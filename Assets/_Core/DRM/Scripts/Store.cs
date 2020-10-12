// =================================
//      (C) Winglett 2020
// =================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winglett.DRM
{
    public abstract class Store
    {
        #region ----PROPERTIES----
        public abstract string ID { get; }
        public abstract string UserID { get; }
        public abstract bool QuitGameOnFailedInitialization { get; }
        public DRMInitialize Initializer { get; private set; }
        #endregion

        #region ----CONFIG----
        private List<DRMComponent> m_Components = new List<DRMComponent>();
        #endregion

        public Store() => Initializer = CreateInitializer();

        protected abstract DRMInitialize CreateInitializer();

        protected void RegisterComponent<T>() where T : DRMComponent
        {
            T component = (T)Activator.CreateInstance(typeof(T));

            if (!m_Components.Contains(component))
            {
                m_Components.Add(component);
            }
        }

        public T GetComponent<T>() where T : DRMComponent
        {
            var found = m_Components.OfType<T>();
            if (found.Count() > 0) return found.First();
            else return null;
        }

        public async Task InitializeComponents()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < m_Components.Count; i++)
            {
                tasks.Add(m_Components[i].OnInitialize());
            }

            await Task.WhenAll(tasks);
        }

        public void DisposeComponents()
        {
            for (int i = 0; i < m_Components.Count; i++)
            {
                m_Components[i].Dispose();
            }
        }
    }
}