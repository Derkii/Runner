using Runner.Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerController _player;

        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().FromInstance(_player).AsSingle();
        }
    }
}