using UnityEngine;

namespace com.alexlopezvega.prototype.vehicle
{
    [System.Serializable]
    public class Control
    {
        [SerializeField] private float outputMaximum = default;
        [SerializeField] private float deltaRate = default;

        private float normalisedTarget = default;

        public float NormalisedTarget
        {
            get => normalisedTarget;
            set => normalisedTarget = Mathf.Clamp(value, -1f, 1f);
        }

        public float Output { get; private set; }
        public float NormalisedOutput => Mathf.InverseLerp(-outputMaximum, outputMaximum, Output);

        public void Update(float dt)
        {
            Output = Mathf.MoveTowards(Output, NormalisedTarget * outputMaximum, deltaRate * dt);
        }
    }
}
