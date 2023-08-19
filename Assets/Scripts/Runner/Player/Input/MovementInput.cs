using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner.Player.Input
{
    public class MovementInput : MonoBehaviour
    {
        [SerializeField] private InputAction _movement;
        public float Input => _movement.ReadValue<float>();

        private void Awake()
        {
            _movement.Enable();
        }

        private void OnDestroy()
        {
            _movement.Dispose();
        }
    }
}