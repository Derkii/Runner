using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner.Player.Jump
{
    public class JumpInputComponent : MonoBehaviour
    {
        [SerializeField] private InputAction _input;
        public event Action Performed;

        private void Awake()
        {
            _input.Enable();

            _input.performed += InvokePerformed;
        }

        private void OnDestroy()
        {
            _input.Dispose();
        }


        private void InvokePerformed(InputAction.CallbackContext obj)
        {
            Performed?.Invoke();
        }
    }
}