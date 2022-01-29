using AndresMoreno.CommonController.Abstract;
using System.Threading.Tasks;
using UnityEngine;

namespace AndresMoreno.CommonController {
    public class Gravity3DController : Gravity {
        private void Awake(){
            m_currentGravityValue = Physics.gravity;
        }

        public override void InGravity(bool _isActive, GameObject[] _objectToMakeIngravited = null) {
            if (_isActive) {
                Physics.gravity = Vector3.zero;
                foreach (var item in _objectToMakeIngravited)
                    item.GetComponent<Rigidbody>().velocity = Vector2.zero;
            } 
            else ResumeGravity();
        }

        public override void ModifyGravity(Vector3 _gravityValue) => Physics.gravity = m_currentGravityValue = _gravityValue;

        protected override async void ResumeGravity() {
            var timeResuming = 0f;
            while (timeResuming < timeToResumeGravity) {
                Physics.gravity = new Vector3(
                    Mathf.Lerp(Physics.gravity.x, m_currentGravityValue.x, timeResuming != 0 ? timeResuming / 3 : 0),
                    Mathf.Lerp(Physics.gravity.y, m_currentGravityValue.y, timeResuming != 0 ? timeResuming / 3 : 0)
                );
                await Task.Yield();
                timeResuming += Time.deltaTime;
                Debug.Log((int)timeResuming + 1);
            }
        }
    }
}
