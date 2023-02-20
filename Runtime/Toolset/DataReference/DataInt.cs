using UnityEngine;

namespace Toolset
{
    [CreateAssetMenu(fileName = "DataEntry", menuName = "Game Data/Int Entry", order = 0)]
    public class DataInt : DataEntry<int>
    {
        public override void Add(int newValue)
        {
            currentValue += newValue;
            base.Add(newValue);
        }
    }
}