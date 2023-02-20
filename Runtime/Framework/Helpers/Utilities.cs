using System.Collections.Generic;
using UnityEngine;

namespace Package.Runtime.Framework.Helpers
{
    public static class Utilities
    {
        private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new();

        public static WaitForSeconds WaitFor(float seconds)
        {
            if (WaitDictionary.TryGetValue(seconds, out var wait)) return wait;

            WaitDictionary[seconds] = new WaitForSeconds(seconds);
            return WaitDictionary[seconds];
        }
    }
}