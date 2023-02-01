using UnityEngine;

namespace Framework
{
    public class CodeRunner : MonoBehaviour
    {
        [SerializeField] private bool runOnAwake = true;
        [SerializeField] private bool destroyOnComplete = false;
        [SerializeField] private CodeBlock codeBlock;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (runOnAwake) Run();
        }

        [ContextMenu("Run")]
        public void Run()
        {
            codeBlock.Execute(this, Completed);
        }

        private void Completed(bool success)
        {
            Debug.Log($"Code runner completed successfully: {success}");
            if (destroyOnComplete) Destroy(gameObject);
        }
    }
}