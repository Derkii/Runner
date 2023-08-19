using Runner.TimeLeft;
using UnityEngine;
using Zenject;

public class TimerInstaller : MonoInstaller
{
    [SerializeField] private TimeLeftCounter _timeLeftCounter;
    public override void InstallBindings()
    {
        Container.Bind<TimeLeftCounter>().FromInstance(_timeLeftCounter).AsSingle();
    }
}