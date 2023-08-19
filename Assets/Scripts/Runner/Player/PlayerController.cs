using System;
using Cysharp.Threading.Tasks;
using Runner.Health;
using Runner.Movement;
using Runner.Player.Animation;
using Runner.Player.Input;
using Runner.Player.Jump;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Runner.Player
{
    [RequireComponent(typeof(JumpInputComponent)), RequireComponent(typeof(JumpComponent)),
     RequireComponent(typeof(SpeedComponent)), RequireComponent(typeof(HealthComponent)),
     RequireComponent(typeof(MovementInput)), RequireComponent(typeof(PhysicsMovement))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PhysicsMovement _movement;
        [SerializeField] private MovementInput _movementInput;
        [SerializeField] private HealthComponent _health;
        [SerializeField] private SpeedComponent _speed;
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private JumpInputComponent _jumpInputComponent;
        [SerializeField] private PlayerAnimationController _animator;
        public event Action<int> HealthChanged;
        public int StartHealth => _health.StartHealth;


        private void Start()
        {
            InitComponents();

            _health.HealthChanged += InvokeHealthChanged;
            _health.Init();
            _jumpInputComponent.Performed += () => TryJump();
        }

        private async UniTaskVoid TryJump()
        {
            await UniTask.WaitForFixedUpdate();
            _jumpComponent.TryJump();
        }

        private void Update()
        {
            _animator.SetHorizontalMovement(_movementInput.Input);
        }

        private void FixedUpdate()
        {
            _speed.AddSpeed();
            _movement.Move(_speed.Speed, new Vector3(_movementInput.Input, 0f, 1));
        }

        private void OnValidate()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            void GetComponentIfNull<TComponent>(ref TComponent componentValue) where TComponent : Component
            {
                if (componentValue == null)
                    TryGetComponent(out componentValue);
            }

            GetComponentIfNull(ref _movement);
            GetComponentIfNull(ref _movementInput);
            GetComponentIfNull(ref _health);
            GetComponentIfNull(ref _speed);
            GetComponentIfNull(ref _jumpComponent);
            GetComponentIfNull(ref _jumpInputComponent);
            GetComponentIfNull(ref _animator);
        }


        private void InvokeHealthChanged(int value)
        {
            if (value <= 0)
            {
#if UNITY_EDITOR
                EditorApplication.isPaused = true;
#elif !UNITY_EDITOR
            throw new NotImplementedException();
#endif
                HealthChanged?.Invoke(0);
                return;
            }

            HealthChanged?.Invoke(value);
        }

        public void Damage(int damage)
        {
            _health.Damage(damage);
        }

        public void DecreaseSpeed(float decrease)
        {
            _speed.DecreaseSpeed(decrease);
        }
    }
}