using System;
using UnityEngine;

namespace Toolset.CodeBlocks
{
    public class CodeRunner : MonoBehaviour
    {
        [SerializeField] private bool persistent = false;
        [SerializeField] private bool runOnAwake = true;
        [SerializeField] private bool destroyOnComplete = false;
        [SerializeField] private bool logging = false;
        [SerializeField] private CodeBlock codeBlock;

        private void Awake()
        {
            if (persistent) DontDestroyOnLoad(gameObject);
            if (runOnAwake) Run();
        }

        [ContextMenu("Run")]
        public void Run()
        {
            LogMessage("Started");
            try
            {
                codeBlock.Run(this, Completed);
            }
            catch (Exception e)
            {
                LogMessage(e.Message);
                Completed(false);
            }
        }

        public void LogMessage(string message)
        {
            if (logging) Debug.Log($"{gameObject.name}: {message}");
        }

        private void Completed(bool success)
        {
            LogMessage(success ? "Completed" : "Failed");
            if (destroyOnComplete) Destroy(gameObject);
        }

        private void OnDestroy() => StopAllCoroutines();
    }
}