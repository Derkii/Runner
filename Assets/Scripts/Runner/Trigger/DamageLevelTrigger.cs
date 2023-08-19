using Runner.Player;
using UnityEngine;

namespace Runner.Trigger
{
    public class DamageLevelTrigger : TriggerComponent<PlayerController>
    {
        [SerializeField] private float _decreaseOnCollision;
        [SerializeField] private int _damage;

        protected override void CustomOnTriggerEnter(PlayerController player)
        {
            Destroy(this);
            player.Damage(_damage);
            player.DecreaseSpeed(_decreaseOnCollision);
        }
    }
}