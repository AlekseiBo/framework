using System;
using UnityEngine;

namespace Package.Runtime.Framework.DataReference
{
    public abstract class DataEntry<T> : ScriptableObject
    {
        public virtual T Value => currentValue;

        [SerializeField] protected T defaultValue;
        [SerializeField] protected T currentValue;

        protected Action<DataEntry<T>> ValueUpdated;

        private void Awake() => currentValue = defaultValue;

        private void OnEnable() => currentValue = defaultValue;

        public virtual T Subscribe(Action<DataEntry<T>> action)
        {
            if (action != null) ValueUpdated += action;
            return currentValue;
        }

        public virtual void RemoveSubscriber(Action<DataEntry<T>> action)
        {
            if (action != null) ValueUpdated -= action;
        }

        public virtual void Set(T newValue)
        {
            if (currentValue.Equals(newValue)) return;

            currentValue = newValue;
            ValueUpdated?.Invoke(this);
        }

        public virtual void Add(T newValue) => ValueUpdated?.Invoke(this);
    }
}