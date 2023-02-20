using System;

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
    }
}