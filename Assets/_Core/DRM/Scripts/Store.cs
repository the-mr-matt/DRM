﻿// =================================
//      (C) Winglett 2020
// =================================

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
        #endregion

        #region ----CONFIG----
        private List<DRMComponent> m_Components = new List<DRMComponent>();
        #endregion

        public Store() => Initializer = CreateInitializer();

        protected abstract DRMInitialize CreateInitializer();

        protected void RegisterComponent<T>(T component) where T : DRMComponent
        {
            if (!m_Components.Contains(component))
            {
                m_Components.Add(component);
            }
        }

        public T GetComponent<T>() where T : DRMComponent
        {
            var found = m_Components.OfType<T>();
            if (found.Count() > 0) return found.First();
            else
            {
                Debug.LogError($"Component of type \"{typeof(T)}\" not found.");
                return null;
            }
        }
    }
}