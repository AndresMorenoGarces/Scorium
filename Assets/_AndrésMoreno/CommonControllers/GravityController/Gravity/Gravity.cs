using UnityEngine;

namespace AndresMoreno.CommonController.Abstract {
    public abstract class Gravity : MonoBehaviour, IControllersNET {
        [SerializeField] protected float timeToResumeGravity { get; set; }
        protected Vector3 m_currentGravityValue { get; set; }

        public abstract void InGravity(bool _isActive, GameObject[] _objectToMakeIngravited = null);
        public abstract void ModifyGravity(Vector3 _gravityValue);
        protected virtual async void ResumeGravity() { }
    }
}