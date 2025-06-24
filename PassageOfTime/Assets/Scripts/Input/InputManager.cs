using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputManager : Singleton<InputManager>
    {
        public InputActionAsset pointerAsset;
        public static event Action<bool> OnPointerAction;
        public Vector2 pointerPosition;

        private void OnEnable()
        {
            pointerAsset.Enable();
            pointerAsset["Hold"].performed += (ctx) => OnPointer(true);
            pointerAsset["Hold"].canceled += (ctx) => OnPointer(false);
        }

        public void Update()
        {
            pointerPosition = pointerAsset["Move"].ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            pointerAsset.Disable();
        }

        private void OnPointer(bool pointerDown)
        {
            OnPointerAction.Invoke(pointerDown);
        }
    }
}
