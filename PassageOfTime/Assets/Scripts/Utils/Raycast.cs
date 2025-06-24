using UnityEngine;

namespace Utils
{
    public class Raycast
    {
        private Camera _camera;

        public Raycast(Camera camera)
        {
            _camera = camera;
        }

        public RaycastHit2D[] GetRaycast(Vector2 position)
        {
            return Physics2D.RaycastAll(_camera.ScreenToWorldPoint(position), Vector2.zero);
        }

        public T GetClosestRaycast<T>(Vector2 position) where T : Component
        {
            var hits = GetRaycast(position);
            if(hits.Length == 0) return default(T);
            var closest = hits[0];
            foreach (var t in hits)
            {
                if (t.transform.position.z < closest.transform.position.z && closest.transform.GetComponent<T>() != null)
                {
                    closest = t;
                }
            }

            if (closest.transform.GetComponent<T>() != null)
            {
                return closest.transform.GetComponent<T>();
            }
            return default(T);
        }
        
    }
}