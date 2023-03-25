using UnityEngine;

namespace Toolset
{
    public static class TransformExtensions
    {
        public static void ClearChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }

        public static void Teleport(this Transform transform, Vector3 position, Quaternion rotation)
        {
            var colliders = transform.GetComponentsInChildren<Collider>();
            foreach (var collider in colliders) collider.enabled = false;
            transform.position = position;
            transform.rotation = rotation;
            foreach (var collider in colliders) collider.enabled = true;
        }
    }
}