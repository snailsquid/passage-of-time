using System;
using Input;
using UnityEngine;

namespace Mechanic.Grab
{
    public class Grabbable : MonoBehaviour
    {
        public bool isGrabbed = false;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Follow()
        {
            // var pointerPosition = InputManager.Instance.pointerPosition;
            // var worldPos = _camera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, transform.position.z));
            // transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);
        }
        private void Update()
        {
            if(isGrabbed) Follow();
        }
    }
}