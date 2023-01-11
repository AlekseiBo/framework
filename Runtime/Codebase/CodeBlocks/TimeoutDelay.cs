using System;
using System.Collections;
using Codebase.Helpers;
using UnityEngine;

namespace Codebase.CodeBlocks
{
    [CreateAssetMenu(fileName = "TimeoutDelay", menuName = "Scriptable Object/Code Blocks/Timeout Delay", order = 0)]
    public class TimeoutDelay : CodeBlock
    {
        [SerializeField] private float duration;

        public override void Execute(CodeRunner runner, Action<bool> completed)
        {
            base.Execute(runner, completed);
            Timeout();
        }

        private void Timeout()
        {
            Debug.Log($"Executing {name}");
            Runner.StartCoroutine(WaitForEnd());
        }

        private IEnumerator WaitForEnd()
        {
            yield return Utilities.WaitFor(duration);
            Debug.Log($"Finished in {duration} seconds");
            Completed?.Invoke(true);
        }
    }
}