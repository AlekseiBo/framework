using System;
using UnityEngine;

namespace Toolset
{
    public abstract class CodeBlock : ScriptableObject
    {
        [SerializeField] protected bool skip;

        protected CodeRunner Runner;

        private Action<bool> completed;

        public virtual void Run(CodeRunner runner, Action<bool> completed)
        {
            this.completed = completed;
            Runner = runner;
            if (skip)
            {
                Runner.LogMessage($"{name} was skipped");
                completed.Invoke(true);
            }
            else
            {
                Execute();
            }
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