using UnityEngine;

namespace Package.Runtime.Framework.DataReference
{
    [CreateAssetMenu(fileName = "DataEntry", menuName = "Game Data/Float Entry", order = 0)]
    public class DataFloat : DataEntry<float>
    {
        public override void Add(float newValue)
        {
            currentValue += newValue;
            base.Add(newValue);
        }
    }
}