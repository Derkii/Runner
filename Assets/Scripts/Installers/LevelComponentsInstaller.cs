using Runner.Level;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelComponentsInstaller : MonoInstaller
    {
        [SerializeField] private LevelRoadBuilder levelRoadBuilder;

        public override void InstallBindings()
        {
            Container.Bind<LevelRoadBuilder>().FromInstance(levelRoadBuilder).AsSingle();
        }
    }
}