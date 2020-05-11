using MiniatureGardenSound.Manager;
using MiniatureGardenSound.Transition;
using MiniatureGardenSound.Transition.Interface;
using Zenject;

namespace MiniatureGardenSound.Installer
{
    public class RainUmbrellaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInitializable), typeof(ITickable)).To<UmbrellaManager>().AsSingle();
            Container.Bind(typeof(IInitializable), typeof(ITransitionable)).To<RainTransition>().AsSingle();
        }
    }
}