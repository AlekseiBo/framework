using System;
using UnityEngine;

namespace Codebase.CodeBlocks
{
    public abstract class CodeBlock : ScriptableObject
    {
        protected Action<bool> Completed;
        protected CodeRunner Runner;

        public virtual void Execute(CodeRunner runner, Action<bool> completed)
        {
            Completed = completed;
            Runner = runner;
        }
    }
}