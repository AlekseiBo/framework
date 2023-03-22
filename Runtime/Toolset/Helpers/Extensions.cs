using System;
using UnityEngine;

namespace Toolset
{
    public static class Extensions
    {
        public static T With<T>(this T self, Action<T> set)
        {
            set?.Invoke(self);
            return self;
        }

        public static T With<T>(this T self, Action<T> set, Func<bool> when)
        {
            if (when()) set?.Invoke(self);
            return self;
        }

        public static T With<T>(this T self, Action<T> set, bool when)
        {
            if (when) set?.Invoke(self);
            return self;
        }

        public static void ClearChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}