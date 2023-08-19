using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Runner.Movement.AutoMovement
{
    public class Translate : AutoMovementMono
    {
        [SerializeField] private Transform _right, _left;

        protected override async UniTaskVoid Move(CancellationToken cancellationToken, float speed)
        {
            var next = _right;
            while (true)
            {
                if (cancellationToken.IsCancellationRequested) break;
                
                var tween = _movableTransform.DOMove(next.position,
                    Vector3.Distance(next.position, _movableTransform.position) / speed);
                await tween.ToUniTask(TweenCancelBehaviour.Kill, cancellationToken);
                next = next == _right ? _left : _right;
            }
        }
    }
}