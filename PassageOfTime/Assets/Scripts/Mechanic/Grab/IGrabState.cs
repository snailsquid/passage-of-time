using UnityEngine;

namespace Mechanic.Grab
{
    public interface IGrabState
    {
        public void OnPointer(bool isDown);
        public void Enter();
        public void Exit();
    }
}