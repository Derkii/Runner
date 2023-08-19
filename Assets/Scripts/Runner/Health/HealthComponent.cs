using System;
using UnityEngine;

namespace Runner.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _startHealth = 5;
        public int Health { get; private set; }
        public int StartHealth => _startHealth;

        public event Action<int> HealthChanged;

        private void Awake()
        {
            Health = _startHealth;
        }

        public void Init()
        {
            HealthChanged?.Invoke(Health);
        }

        public void Damage(int damage)
        {
            if (damage < 0) throw new ArgumentException(nameof(damage));
            Health -= damage;
            HealthChanged?.Invoke(Health);
        }
    }
}