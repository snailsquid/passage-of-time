using System;
using Input;
using UnityEngine;

namespace Mechanic.Grab
{
    public class Grabbable : MonoBehaviour
    {
        public bool isGrabbed = false;
        private Camera _camera;
        private float currentX;
        private float currentY;
        public float smoothFactor = 0.1f;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Follow()
        {
            var pointerPosition = InputManager.Instance.pointerPosition;
            var worldPos = _camera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, Math.Abs(_camera.transform.position.z - transform.position.z)));
            var newPos = new Vector3(worldPos.x, worldPos.y, transform.position.z);
            currentX = Mathf.Lerp(currentX, newPos.x, smoothFactor);
            currentY = Mathf.Lerp(currentY, newPos.y, smoothFactor);
            transform.position = new Vector3(currentX, currentY, transform.position.z);
        }
        private void Update()
        {
            if(isGrabbed) Follow();
        }
    }
}