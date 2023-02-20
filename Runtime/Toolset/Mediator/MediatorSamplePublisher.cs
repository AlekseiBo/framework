using Toolset.Helpers;
using UnityEngine;

namespace Toolset.Mediator
{
    public class MediatorSamplePublisher : MonoBehaviour
    {
        private MediatorSampleCommand command = new();

        private void FixedUpdate()
        {
            var command = new MediatorSampleCommand().With(e => e.TimeValue = Time.time);
            Mediator.Publish(command);
        }
    }
}