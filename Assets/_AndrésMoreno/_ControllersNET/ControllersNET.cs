using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AndresMoreno {
    public class ControllersNET : MonoBehaviour{
        private static ControllersNET m_instance;
        public static ControllersNET Instance { get {
            if (m_instance == null) {
                var controllersNET = new GameObject("ControllersNET");
                controllersNET.AddComponent<ControllersNET>();
                m_instance = controllersNET.GetComponent<ControllersNET>();
                m_instance.Initialize();
            }
            return m_instance;
        }}

        private Dictionary<Type, IControllersNET> m_controllersInstantiated;

        private void Initialize() {
            DontDestroyOnLoad(gameObject);
            var settings = Resources.LoadAll<ControllersNET_Settings>("ControllersNET_Settings");
            if (settings is { Length: > 0 }) 
                foreach (var item in settings) item.Initialize();
            else
                Debug.LogWarning("The settings asset reference is null");
            m_controllersInstantiated = new Dictionary<Type, IControllersNET>();
        }

        //============================================================
        public T GetController<T>() where T : IControllersNET{
            // Check if the controller was previously instantiated
            if (m_controllersInstantiated.ContainsKey(typeof(T))) return (T)m_controllersInstantiated[typeof(T)];

            // Find if the controller exist in the scene
            T controller;
            if (FindObjectsOfType<GameObject>().OfType<T>().Any(x => x.gameObject.GetComponent<T>() != null)) {
                controller = FindObjectsOfType<GameObject>().OfType<T>().First(x => x is T);
                m_controllersInstantiated.Add(typeof(T), controller);
                return controller;
            }

            // Instantiate the controller in the scene
            var controllerAsset = ControllersNET_Settings.GetControllerAsset<T>();
            if (controllerAsset == null) return default;

            GameObject controllerAssetObject = Instantiate(controllerAsset.gameObject, transform);
            controller = controllerAssetObject.GetComponent<T>();
            m_controllersInstantiated.Add(typeof(T), controller);

            return controller;
        }
    }
}
