using UnityEngine;

namespace Runner.Block
{
    public class BlockComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _longestTransform;
        public float Size => _longestTransform.lossyScale.z;
    }
}
