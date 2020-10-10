// =================================
//      (C) Winglett 2020
// =================================

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Winglett.DRM
{
    public abstract class Store
    {
        #region ----PROPERTIES----
        public abstract string ID { get; }
        public DRMInitialize Initializer { get; private set; }
        public abstract string UserID { get; }
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

        public void InitializeComponents()
        {
            for (int i = 0; i < m_Components.Count; i++)
            {
                m_Components[i].OnInitialize();
            }
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