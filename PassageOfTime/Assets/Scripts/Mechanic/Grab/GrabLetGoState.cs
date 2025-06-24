using Input;
using UnityEngine;

namespace Mechanic.Grab
{
    public class GrabLetGoState : IGrabState
    {
        private readonly Grab _grab;

        public GrabLetGoState(Grab grab)
        {
            _grab = grab;
        }

        public void OnPointer(bool isDown)
        {
            if (isDown){
                _grab.ChangeState(_grab.GrabHoldingState);
            }
        }

        public void Enter()
        {
            _grab.SetGrabObject(null);
            var position = InputManager.Instance.pointerPosition;
            var trigger = _grab.Raycast.GetClosestRaycast<GrabTrigger>(position);
            trigger?.Trigger(_grab?.grabObject);
        }

        public void Exit()
        {
            
        }
    }
}