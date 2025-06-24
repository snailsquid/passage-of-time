using Input;
using UnityEngine;

namespace Mechanic.Grab
{
    public class GrabHoldingState : IGrabState
    {
        private readonly Grab _grab;
        public GrabHoldingState(Grab grab)
        {
            _grab = grab;
        }

        public void OnPointer(bool isDown)
        {
            if (!isDown)
            {
                _grab.ChangeState(_grab.GrabLetGoState);
            }
        }

        public void Enter()
        {
            var position = InputManager.Instance.pointerPosition;
            var grabObject = _grab.Raycast.GetClosestRaycast<Grabbable>(position);
            Debug.Log(grabObject);
            _grab.SetGrabObject(grabObject);
        }

        public void Exit()
        {
        }
    }
}