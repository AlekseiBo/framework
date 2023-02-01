using Codebase.Helpers;
using UnityEngine;

namespace Samples
{
    public class MediatorSamplePublisher : MonoBehaviour
    {
        private MediatorSampleCommand command = new();

        private void FixedUpdate()
        {
            var command = new MediatorSampleCommand().With(e => e.TimeValue = Time.time);
            Codebase.Mediator.Mediator.Publish(command);
        }
    }
}