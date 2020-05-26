using MiniatureGardenSound.Cycle;
using MiniatureGardenSound.Transition;
using Zenject;

namespace MiniatureGardenSound.Installer
{
    public class DriveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DriveTransition>().AsCached();
            Container.BindInterfacesTo<SceneCycle>().AsSingle();
        }
    }
}