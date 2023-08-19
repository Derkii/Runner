using UnityEngine;

namespace Runner.Movement
{
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidBody;

        public void OnValidate()
        {
            if (_rigidBody == null) TryGetComponent(out _rigidBody);
        }

        public void Move(float speed, Vector3 direction)
        {
            var velocity = direction * speed;
            _rigidBody.velocity = new Vector3(velocity.x, _rigidBody.velocity.y, velocity.z);
        }
    }
}