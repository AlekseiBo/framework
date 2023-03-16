using UnityEngine;

namespace Toolset
{
    [RequireComponent(typeof(Canvas))]
    public class Billboard : MonoBehaviour
    {
        private Camera mainCam;

        private void Start() => CheckCamera();

        private void FixedUpdate()
        {
            if (CheckCamera())
                transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position, Vector3.up);
        }

        private bool CheckCamera()
        {
            if (mainCam != null) return true;

            mainCam = Camera.main;
            if (mainCam == null) return false;

            GetComponent<Canvas>().worldCamera = mainCam;
            return true;
        }
    }
}