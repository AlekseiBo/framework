﻿using System;
using System.Collections;
using Framework;
using UnityEngine;

namespace Samples
{
    [CreateAssetMenu(fileName = "TimeoutDelay", menuName = "Code Blocks/Timeout Delay", order = 0)]
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
            Runner.StartCoroutine(WaitForEnd());
        }

        private IEnumerator WaitForEnd()
        {
            yield return Utilities.WaitFor(duration);
            Complete(true);
        }
    }
}