using UnityEngine;

namespace Toolset
{
    [CreateAssetMenu(fileName = "InstantiatePrefab", menuName = "Code Blocks/Instantiate Prefab", order = 0)]
    public class InstantiatePrefab : CodeBlock
    {
        [SerializeField] private GameObject prefab;

        protected override void Execute()
        {
            Instantiate(prefab).With(e => e.name = prefab.name);
            Complete(true);
        }
    }
}