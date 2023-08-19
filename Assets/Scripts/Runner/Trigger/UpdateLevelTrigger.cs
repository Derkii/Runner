using Runner.Level;
using Runner.Player;
using Zenject;

namespace Runner.Trigger
{
    public class UpdateLevelTrigger : TriggerComponent<PlayerController>
    {
        [Inject] private LevelRoadBuilder _level;

        protected override void CustomOnTriggerEnter(PlayerController player)
        {
            _level.BuildBlock();
        }
    }
}