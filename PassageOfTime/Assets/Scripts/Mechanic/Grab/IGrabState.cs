using UnityEngine;

namespace Mechanic.Grab
{
    public interface IGrabState
    {
        public void OnPointer(bool isDown, Vector2 position);
        public void Enter();
        public void Exit();
    }
}