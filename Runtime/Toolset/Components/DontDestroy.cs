using UnityEngine;

namespace Toolset
{
    public class DontDestroy : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(gameObject);
    }
}