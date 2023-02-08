using UnityEngine;

namespace Framework
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