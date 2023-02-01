using Framework;
using UnityEngine;

namespace Samples
{
    public class MediatorSampleSubscriber : MonoBehaviour
    {
        private void OnEnable() => Mediator.Subscribe<MediatorSampleCommand>(OnCommand);

        private void OnDisable()
        {
            Mediator.RemoveSubscriber<MediatorSampleCommand>(OnCommand);
        }

        private void OnCommand(MediatorSampleCommand command) => Debug.Log(command.TimeValue);
    }
}