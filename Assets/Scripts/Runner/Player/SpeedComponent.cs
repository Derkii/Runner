using System;
using UnityEngine;

namespace Runner.Player
{
    public class SpeedComponent : MonoBehaviour
    {
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _additionalSpeed;
        [SerializeField] private float _maxSpeed;
        public float Speed { get; private set; }

        private void Awake()
        {
            Speed = _startSpeed;
        }

        public void AddSpeed()
        {
            if (Speed + _additionalSpeed > _maxSpeed)
            {
                Speed = _maxSpeed;
                return;
            }

            Speed += _additionalSpeed;
        }

        public void DecreaseSpeed(float decrease)
        {
            if (decrease <= 0f) throw new ArgumentException(nameof(decrease));

            Speed -= decrease;
        }
    }
}