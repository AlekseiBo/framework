using UnityEngine;

namespace Framework
{
    [CreateAssetMenu(fileName = "DataEntry", menuName = "Game Data/Float Entry", order = 0)]
    public class DataFloat : DataEntry<float>
    {
        public override void Add(float otherValue)
        {
            currentValue += otherValue;
            base.Add(otherValue);
        }
    }
}