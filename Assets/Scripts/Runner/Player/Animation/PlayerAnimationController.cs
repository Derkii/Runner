using UnityEngine;

namespace Runner.Player.Animation
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private readonly int _horizontalMovementKey = Animator.StringToHash("HorizontalMovement");
        
        public void SetHorizontalMovement(float value)
        {
            _animator.SetFloat(_horizontalMovementKey, value);
        }
    }
}