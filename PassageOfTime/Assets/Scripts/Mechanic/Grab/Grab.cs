using Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Mechanic.Grab
{
    public class Grab : MonoBehaviour
    {
        public bool isPointerDown = false;
        private IGrabState _currentGrabState;
        [SerializeField] private Transform grabbedObject;
        public GrabHoldingState GrabHoldingState;
        public GrabLetGoState GrabLetGoState;
        public Raycast Raycast;
        public Grabbable grabObject { get; private set; }

        private void Start()
        {
            InputManager.OnPointerAction += OnPointer;        
            GrabHoldingState = new GrabHoldingState(this);
            GrabLetGoState = new GrabLetGoState(this);
            Raycast = new Raycast(Camera.main);
        }

        private void OnPointer(bool isDown, Vector2 position)
        {
            switch (isPointerDown)
            {
                case false when isDown:
                    isPointerDown = true;
                    _currentGrabState.OnPointer(true, position);
                    break;
                case true when !isDown:
                    isPointerDown = false;
                    _currentGrabState.OnPointer(false, position);
                    break;
            }
        }

        public void SetGrabObject(Grabbable obj)
        {
            this.grabObject = obj;
        }
        
        public void ChangeState(IGrabState state)
        {
            _currentGrabState.Exit();
            _currentGrabState = state;
            _currentGrabState.Enter();
        }

    }
}
