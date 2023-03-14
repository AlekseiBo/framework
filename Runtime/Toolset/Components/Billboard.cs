using UnityEngine;

namespace Toolset
{
    [RequireComponent(typeof(Canvas))]
    public class Billboard : MonoBehaviour
    {
        private Camera _cam;

        private void Start()
        {
            _cam = Camera.main;
            GetComponent<Canvas>().worldCamera = _cam;
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position, Vector3.up);
        }
    }
}