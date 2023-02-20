using System;
using UnityEngine;

namespace Toolset.CodeBlocks
{
    [CreateAssetMenu(fileName = "CodeBlockQueue", menuName = "Code Blocks/Code Block Queue", order = 0)]
    public class CodeBlockQueue : CodeBlock
    {
        [SerializeField] private bool stopOnFail = true;
        [SerializeField] private CodeBlock[] blocks;

        private int currentIndex = 0;

        public override void Run(CodeRunner runner, Action<bool> completed)
        {
            currentIndex = 0;
            base.Run(runner, completed);
        }

        protected override void Execute()
        {
            if (currentIndex < blocks.Length)
            {
                try
                {
                    blocks[currentIndex].Run(Runner, BlockCompleted);
                }
                catch (Exception e)
                {
                    Runner.LogMessage(e.Message);
                    BlockCompleted(false);
                }
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
                Execute();
            }
            else
            {
                Complete(false);
            }
        }
    }
}