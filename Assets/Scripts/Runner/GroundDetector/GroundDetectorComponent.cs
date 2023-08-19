using System;
using UnityEngine;

namespace Runner.GroundDetector
{
    public class GroundDetectorComponent : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] private float _distance;
        [SerializeField] private LayerMask _groundLayer;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_point.position, _point.position + -_point.up * _distance);
        }

        public bool OnGround
        {
            get
            {
                return Physics.Raycast(_point.position, -_point.up, _distance, _groundLayer);
            }
        }
    }
}