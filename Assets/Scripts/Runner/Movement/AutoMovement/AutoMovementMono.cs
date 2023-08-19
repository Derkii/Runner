using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runner.Movement.AutoMovement
{
    public abstract class AutoMovementMono : MonoBehaviour
    {
        [SerializeField] protected Transform _movableTransform;
        [SerializeField] private float _speed;

        private void Start()
        {
            Move(this.GetCancellationTokenOnDestroy(), _speed);
        }

        protected abstract UniTaskVoid Move(CancellationToken cancellationToken, float speed);
    }
}