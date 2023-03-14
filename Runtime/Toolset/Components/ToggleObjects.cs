using UnityEngine;

namespace Toolset
{
    public class ToggleObjects : MonoBehaviour
    {
        [SerializeField] private GameObject[] objects;

        public void Toggle()
        {
            foreach (var obj in objects)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }
}