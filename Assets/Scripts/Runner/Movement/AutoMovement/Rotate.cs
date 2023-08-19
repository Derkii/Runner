using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runner.Movement.AutoMovement
{
    public class Rotate : AutoMovementMono
    {
        protected override async UniTaskVoid Move(CancellationToken cancellationToken, float speed)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested) break;
                _movableTransform.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime);
                await UniTask.Yield(cancellationToken);
                if (cancellationToken.IsCancellationRequested) break;
            }
        }
    }
}