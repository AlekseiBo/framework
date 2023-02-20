using UnityEngine;

namespace Package.Runtime.Framework.DataReference
{
    [CreateAssetMenu(fileName = "DataEntry", menuName = "Game Data/Trigger Entry", order = 0)]
    public class DataTrigger : DataEntry<bool>
    {
        public override void Set(bool newValue)
        {
            base.Set(newValue);
            currentValue = false;
        }
    }
}