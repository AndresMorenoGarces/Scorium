using AndresMoreno;
using AndresMoreno.CommonController;
using Scorium.Controller;
using UnityEngine;

namespace Scorium.Gameplay {
    public abstract class Gameplay : MonoBehaviour {
        protected static ScoreController ScoreController;
        protected static Gravity2DController Gravity2DController;
        private static bool SettedValues = false;

        private void Awake() {
            if (!SettedValues)
                GetReferences();
        }

        static void GetReferences() {
            if (Gravity2DController == null) Gravity2DController = ControllersNET.Instance.GetController<Gravity2DController>();
            if (ScoreController == null) ScoreController = ControllersNET.Instance.GetController<ScoreController>();
        }
    }
}
