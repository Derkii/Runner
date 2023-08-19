using UnityEngine;

namespace Runner.Trigger
{
    public abstract class TriggerComponent<TComponent> : MonoBehaviour where TComponent : Component
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TComponent component)) CustomOnTriggerEnter(component);
        }

        protected abstract void CustomOnTriggerEnter(TComponent player);
    }
}