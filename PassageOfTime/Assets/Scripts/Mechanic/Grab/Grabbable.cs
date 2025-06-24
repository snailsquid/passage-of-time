using Input;
using UnityEngine;

namespace Mechanic.Grab
{
    public class Grabbable : MonoBehaviour
    {
        public bool isGrabbed = false;

        private void Follow()
        {
            transform.position = InputManager.Instance.pointerPosition;
        }
        private void Update()
        {
            if(isGrabbed) Follow();
        }
    }
}