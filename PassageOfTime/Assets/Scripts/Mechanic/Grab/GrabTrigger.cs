using UnityEngine;

namespace Mechanic.Grab
{
    public abstract class GrabTrigger : MonoBehaviour
    {
        public Grabbable _grabbable;
        public void Trigger(Grabbable grab)
        {
            if (grab == null) return;
            _grabbable = grab;
            TriggerAction();
        }

        public abstract void TriggerAction();
    }
}