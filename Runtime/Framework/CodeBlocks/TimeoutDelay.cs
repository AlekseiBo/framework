using System.Collections;
using Package.Runtime.Framework.Helpers;
using UnityEngine;

namespace Package.Runtime.Framework.CodeBlocks
{
    [CreateAssetMenu(fileName = "TimeoutDelay", menuName = "Code Blocks/Timeout Delay", order = 0)]
    public class TimeoutDelay : CodeBlock
    {
        [SerializeField] private float duration;

        protected override void Execute()
        {
            Runner.StartCoroutine(WaitForEnd());
        }

        private IEnumerator WaitForEnd()
        {
            yield return Utilities.WaitFor(duration);
            Complete(true);
        }
    }
}