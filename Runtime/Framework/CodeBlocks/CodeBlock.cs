using System;
using UnityEngine;

namespace Package.Runtime.Framework.CodeBlocks
{
    public abstract class CodeBlock : ScriptableObject
    {
        protected CodeRunner Runner;

        private Action<bool> completed;

        public virtual void Run(CodeRunner runner, Action<bool> completed)
        {
            this.completed = completed;
            Runner = runner;
            Execute();
        }

        protected abstract void Execute();

        protected void Complete(bool success)
        {
            if (Runner != null)
            {
                if (this != null)
                {
                    var result = success ? "completed" : "failed";
                    Runner.LogMessage($"{name} {result}");
                }

                completed.Invoke(success);
            }
        }
    }
}