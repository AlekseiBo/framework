using System;
using UnityEngine;

namespace Framework
{
    public abstract class CodeBlock : ScriptableObject
    {
        protected CodeRunner Runner;

        private Action<bool> completed;

        public virtual void Execute(CodeRunner runner, Action<bool> completed)
        {
            this.completed = completed;
            Runner = runner;
        }

        protected void Complete(bool success)
        {
            if (Runner != null)
            {
                var result = success ? "completed successfully" : "completion failed";
                Runner.LogMessage($"{name} {result}");
                completed.Invoke(success);
            }
        }
    }
}