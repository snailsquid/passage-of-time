using UnityEngine;

namespace Mechanic.Grab
{
    public class GrabHoldingState : IGrabState
    {
        private Grab _grab;
        public GrabHoldingState(Grab grab)
        {
            _grab = grab;
        }

        public void OnPointer(bool isDown, Vector2 position)
        {
            if (isDown)
            {
                _grab.SetGrabObject(_grab.Raycast.GetClosestRaycast<Grabbable>(position));
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