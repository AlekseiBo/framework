using UnityEngine;

namespace Toolset.CodeBlocks
{
    [CreateAssetMenu(fileName = "InstantiatePrefab", menuName = "Code Blocks/Instantiate Prefab", order = 0)]
    public class InstantiatePrefab : CodeBlock
    {
        [SerializeField] private GameObject prefab;

        protected override void Execute()
        {
            Instantiate(prefab);
            Complete(true);
        }
    }
}