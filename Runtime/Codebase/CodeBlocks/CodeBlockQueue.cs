﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.CodeBlocks
{
    [CreateAssetMenu(fileName = "CodeBlockQueue", menuName = "Scriptable Object/Code Blocks/Code Block Queue", order = 0)]
    public class CodeBlockQueue : CodeBlock
    {
        [SerializeField] private CodeBlock[] blocks;

        private int currentIndex = 0;

        public override void Execute(CodeRunner runner, Action<bool> completed)
        {
            base.Execute(runner, completed);

            currentIndex = 0;
            ExecuteQueue();
        }

        private void ExecuteQueue()
        {
            if (currentIndex < blocks.Length)
            {
                blocks[currentIndex].Execute(Runner, BlockCompleted);
            }
            else
            {
                Debug.Log($"{this.name} completed successfully");
                Completed?.Invoke(true);
            }
        }

        private void BlockCompleted(bool success)
        {
            if (success)
            {
                currentIndex++;
                ExecuteQueue();
            }
            else
            {
                Completed?.Invoke(false);
            }
        }
    }
}