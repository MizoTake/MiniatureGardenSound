using MiniatureGardenSound.Cycle;
using MiniatureGardenSound.Manager;
using MiniatureGardenSound.Transition;
using Zenject;

namespace MiniatureGardenSound.Installer
{
    public class RainUmbrellaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UmbrellaManager>().AsSingle();
            Container.BindInterfacesTo<RainTransition>().AsCached();
            Container.BindInterfacesTo<SceneCycle>().AsSingle();
        }
    }
}