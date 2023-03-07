using UnityEngine;

namespace Toolset
{
    public class MediatorSampleSubscriber : MonoBehaviour
    {
        private void OnEnable() => Command.Subscribe<MediatorSampleCommand>(OnCommand);

        private void OnDisable()
        {
            Command.RemoveSubscriber<MediatorSampleCommand>(OnCommand);
        }

        private void OnCommand(MediatorSampleCommand command) => Debug.Log(command.TimeValue);
    }
}