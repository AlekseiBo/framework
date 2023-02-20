using System.Collections.Generic;

namespace Package.Runtime.Framework.Mediator
{
    public static class Mediator
    {
        private static readonly Dictionary<System.Type, System.Delegate> subscribers = new();

        public static void Subscribe<T>(MediatorCallback<T> callback) where T : IMediatorCommand
        {
            if (callback == null) return;
            var callbackType = typeof(T);
            if (subscribers.ContainsKey(callbackType))
                subscribers[callbackType] = System.Delegate.Combine(subscribers[callbackType], callback);
            else
                subscribers.Add(callbackType, callback);
        }

        public static void RemoveSubscriber<T>(MediatorCallback<T> callback) where T : IMediatorCommand
        {
            if (callback == null) return;
            var callbackType = typeof(T);
            if (subscribers.ContainsKey(callbackType))
            {
                var delegateToRemove = subscribers[callbackType];
                delegateToRemove = System.Delegate.Remove(delegateToRemove, callback);
                if (delegateToRemove == null)
                    subscribers.Remove(callbackType);
                else
                    subscribers[callbackType] = delegateToRemove;
            }
        }

        public static void Publish<T>(T callback) where T : IMediatorCommand
        {
            var callbackType = typeof(T);
            if (subscribers.ContainsKey(callbackType))
                subscribers[callbackType].DynamicInvoke(callback);
        }
    }
}