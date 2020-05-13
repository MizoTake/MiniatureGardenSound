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
            Container.BindInterfacesAndSelfTo<UmbrellaManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<RainTransition>().AsCached();
        }
    }
}