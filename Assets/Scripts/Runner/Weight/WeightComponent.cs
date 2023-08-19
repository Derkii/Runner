using UnityEngine;

namespace Runner.Weight
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeightComponent : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidBody.AddForce(Physics.gravity * _rigidBody.mass * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }
}