using System;
using System.Collections.Generic;

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

        public static void Increment<K, V>(this Dictionary<K, V> self, K key, V increment) where V : IConvertible
        {
            if (self.TryGetValue(key, out var value))
                self[key] = (V)Convert.ChangeType(Convert.ToDouble(value) + Convert.ToDouble(increment), typeof(V));
            else
                self[key] = increment;
        }
    }
}