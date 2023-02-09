using System;
using UnityEngine;

namespace Framework
{
    [CreateAssetMenu(fileName = "CodeBlockQueue", menuName = "Code Blocks/Code Block Queue", order = 0)]
    public class CodeBlockQueue : CodeBlock
    {
        [SerializeField] private bool stopOnFail = true;
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
                Complete(true);
            }
        }

        private void BlockCompleted(bool success)
        {
            if (success || !stopOnFail)
            {
                currentIndex++;
                ExecuteQueue();
            }
            else
            {
                Complete(false);
            }
        }
    }
}