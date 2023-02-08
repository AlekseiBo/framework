using UnityEngine;

namespace Framework
{
    [CreateAssetMenu(fileName = "DataEntry", menuName = "Game Data/String Entry", order = 0)]
    public class DataString : DataEntry<string>
    {
        public override void Add(string otherValue)
        {
            currentValue += otherValue;
            base.Add(otherValue);
        }
    }
}