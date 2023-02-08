using UnityEngine;

namespace Framework
{
    [CreateAssetMenu(fileName = "DataEntry", menuName = "Game Data/Int Entry", order = 0)]
    public class DataInt : DataEntry<int>
    {
        public override void Add(int otherValue)
        {
            currentValue += otherValue;
            base.Add(otherValue);
        }
    }
}