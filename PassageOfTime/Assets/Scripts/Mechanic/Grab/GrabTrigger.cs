using UnityEngine;

namespace Mechanic.Grab
{
    public class GrabTrigger : MonoBehaviour
    {
        public void Trigger(Grabbable grab)
        {
            if (grab == null) return;
        }
    }
}