using UnityEngine;

namespace Toolset
{
    [CreateAssetMenu(fileName = "InstantiatePrefab", menuName = "Code Blocks/Instantiate Prefab", order = 0)]
    public class InstantiatePrefab : CodeBlock
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private bool dontDestroyOnLoad;

        protected override void Execute()
        {
            Instantiate(prefab)
                .With(e => e.name = prefab.name)
                .With(e => e.AddComponent<DontDestroyOnLoad>(), when: dontDestroyOnLoad);
            Complete(true);
        }
    }
}