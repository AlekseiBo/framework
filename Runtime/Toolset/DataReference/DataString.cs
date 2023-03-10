using UnityEngine;

namespace Toolset
{
    [CreateAssetMenu(fileName = "DataEntry", menuName = "Game Data/String Entry", order = 0)]
    public class DataString : DataEntry<string>
    {
        public override void Add(string newValue)
        {
            currentValue += newValue;
            base.Add(newValue);
        }
    }
}