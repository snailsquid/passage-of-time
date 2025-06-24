using UnityEngine;

namespace Mechanic.Grab
{
    public class GrabLetGoState : IGrabState
    {
        private Grab _grab;

        public GrabLetGoState(Grab grab)
        {
            _grab = grab;
        }

        public void OnPointer(bool isDown, Vector2 position)
        {
            if (!isDown)
            {
                _grab.grabObject.isGrabbed = false;
                _grab.Raycast.GetClosestRaycast<GrabTrigger>(position).Trigger(_grab.grabObject);
            }
            else
            {
                _grab.ChangeState(_grab.GrabHoldingState);
            }
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}