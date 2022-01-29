using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AndresMoreno { 
    [CreateAssetMenu(fileName = "ControllersNET_Settings", menuName = "Assets/_AndrésMoreno/ControllersNET_Settings")]
    public class ControllersNET_Settings : ScriptableObject {
        [SerializeField] private GameObject[] controllersAssets;

        private static List<GameObject> ControllersAssets;

        static ControllersNET_Settings() => ControllersAssets = new();
        
        public void Initialize() {
            foreach (var item in controllersAssets) 
                if (!ControllersAssets.Contains(item)) 
                    ControllersAssets.Add(item);
        }
        public static T GetControllerAsset<T>() where T : IControllersNET {
            if (ControllersAssets.Any(x => x != null && x.GetComponent<T>() != null)) {
                T controller = ControllersAssets.First(x => x != null && x.gameObject.GetComponent<T>() != null).GetComponent<T>();
                return controller;
            }
            Debug.LogWarning($"The controller of type {typeof(T)} doesn't exist in settings asset");
            return default(T);
        }
    }
}
