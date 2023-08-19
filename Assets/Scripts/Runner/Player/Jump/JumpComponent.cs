using Runner.GroundDetector;
using UnityEngine;

namespace Runner.Player.Jump
{
    public class JumpComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private GroundDetectorComponent _groundDetector;
        [SerializeField] private float _jumpForce;

        public bool TryJump()
        {
            if (_groundDetector.OnGround)
            {
                _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            }
            
            return _groundDetector.OnGround;
        }
    }
}